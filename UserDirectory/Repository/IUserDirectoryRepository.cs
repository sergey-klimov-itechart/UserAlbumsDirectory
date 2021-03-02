using System.Collections.Generic;
using System.Threading.Tasks;
using UserDirectory.Models;

namespace UserDirectory.Repository
{
    public interface IUserDirectoryRepository
    {
        public Task<IEnumerable<Album>> GetAlbumsAsync();
        public Task<User> GetUserByIdAsync(int id);
        public Task<IEnumerable<Photo>> GetPhotosByAlbumIdAsync(int albumId);
        public Task<IEnumerable<User>> GetUsersAsync();
        public Task<Album> GetAlbumByIdAsync(int id);
        public Task<IEnumerable<Post>> GetPostsByUserIdAsync(int id);
    }
}
