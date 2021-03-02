using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserDirectory.Infrastructure;
using UserDirectory.Models;
using UserDirectory.Repository;

namespace UserDirectory.BusinessLayer
{
    public class AlbumService : IAlbumService
    {
        private readonly IUserDirectoryRepository _repo;

        public AlbumService(IUserDirectoryRepository repository)
        {
            _repo = repository;
        }

        public async Task<IDictionary<Album,User>> SearchAlbums(string searchString)
        {
            var albumCollection = await _repo.GetAlbumsAsync();
            var albumList = albumCollection.ToList();
            var filteredAlbums = FilterAlbums(albumList, searchString);
            
            var userCollection = await _repo.GetUsersAsync();
            var userList = userCollection.ToList();
            var filteredUsers = FilterUsers(userList, searchString);

            List<Album> allAlbums =new List<Album>();

            if (!string.IsNullOrEmpty(searchString))
            {
                var albumsFilteredByUsers = new List<Album>();
                foreach (var user in filteredUsers)
                {
                    var albums = albumList.Where(t => t.UserId == user.Id).ToList();
                    albumsFilteredByUsers.AddRange(albums);
                }

                allAlbums.AddRange(filteredAlbums.Union(albumsFilteredByUsers, new AlbumComparer()).ToList());
            }
            else
            {
                allAlbums.AddRange(filteredAlbums);
            }

            Dictionary<Album, User> dict = new Dictionary<Album, User>();
            foreach (var album in allAlbums)
            {
                dict.Add(album, userList.FirstOrDefault(t => t.Id == album.UserId));
            }

            return dict;
        }

        public async Task<Dictionary<int, IEnumerable<Photo>>> GetPhotosForAlbums(IEnumerable<Album> albumList)
        {
            var photosTasks = new List<Task<IEnumerable<Photo>>>();
            foreach (var album in albumList)
            {
                var photosPromise = _repo.GetPhotosByAlbumIdAsync(album.Id);
                photosTasks.Add(photosPromise);
            }
            var photosOfAlbums = await Task.WhenAll(photosTasks);

            Dictionary<int, IEnumerable<Photo>> dictPhotosOfAlbums = new Dictionary<int, IEnumerable<Photo>>();
            foreach (var photosOfAlbum in photosOfAlbums)
            {
                var photosArray = photosOfAlbum.ToList();
                dictPhotosOfAlbums.Add(photosArray.First().AlbumId, photosArray);
            }

            return dictPhotosOfAlbums;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user= await _repo.GetUserByIdAsync(id);

            return user;
        }

        public async Task<IEnumerable<Post>> GetPostsByUserIdAsync(int id)
        {
            var posts = await _repo.GetPostsByUserIdAsync(id);

            return posts;
        }

        public async Task<IEnumerable<Photo>> GetPhotosByAlbumIdAsync(int id)
        {
            var photos = await _repo.GetPhotosByAlbumIdAsync(id);

            return photos;
        }

        public async Task<Album> GetAlbumByIdAsync(int id)
        {
            var album = await _repo.GetAlbumByIdAsync(id);

            return album;
        }

        private IList<Album> FilterAlbums(IList<Album> albumCollection, string searchString)
        {
            return string.IsNullOrEmpty(searchString)
                ? albumCollection
                : albumCollection.Where(t => t.Title.ToLower().Contains(searchString.ToLower())).ToList();
        }

        private IEnumerable<User> FilterUsers( IList<User> userCollection, string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                return userCollection;
            }

            var lowerSearchString = searchString.ToLower();

            return userCollection.Where(t =>
                t.UserName.ToLower().Contains(lowerSearchString) ||
                t.Name.ToLower().Contains(lowerSearchString)).ToList();
        }
    }
}
