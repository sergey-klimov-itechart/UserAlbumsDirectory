using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserDirectory.Models;

namespace UserDirectory.BusinessLayer
{
    public interface IAlbumService
    {
        public Task<IDictionary<Album, User>> SearchAlbums(string searchString);
        public Task<Dictionary<int, IEnumerable<Photo>>> GetPhotosForAlbums(IEnumerable<Album> albumList);
        public Task<User> GetUserByIdAsync(int id);
        public Task<IEnumerable<Post>> GetPostsByUserIdAsync(int id);
        public Task<IEnumerable<Photo>> GetPhotosByAlbumIdAsync(int id);
        public Task<Album> GetAlbumByIdAsync(int id);
    }
}
