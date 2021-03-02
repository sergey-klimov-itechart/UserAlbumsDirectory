using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UserDirectory.Infrastructure;
using UserDirectory.Models;

namespace UserDirectory.Repository
{
    public class JsonplaceholderRepository : IUserDirectoryRepository
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        public async Task<IEnumerable<Album>> GetAlbumsAsync()
        {
            var url = "https://jsonplaceholder.typicode.com/albums";
            var response = await HttpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var resultString = await response.Content.ReadAsStringAsync();
                var albums = JsonConvert.DeserializeObject<List<Album>>(resultString);

                return albums;
            }

            throw new HttpResponseException();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var url = $"https://jsonplaceholder.typicode.com/users/{id}";
            var response = await HttpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var resultString = await response.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<User>(resultString);

                return user;
            }

            throw new HttpResponseException();
        }

        public async Task<IEnumerable<Photo>> GetPhotosByAlbumIdAsync(int albumId)
        {
            var url = $"https://jsonplaceholder.typicode.com/albums/{albumId}/photos";
            var response = await HttpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var resultString = await response.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<IEnumerable<Photo>>(resultString);
                return user;
            }

            throw new HttpResponseException();
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            var url = "https://jsonplaceholder.typicode.com/users";
            var response = await HttpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var resultString = await response.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<IEnumerable<User>>(resultString);
                return user;
            }

            throw new HttpResponseException();
        }

        public async Task<Album> GetAlbumByIdAsync(int id)
        {
            var url = $"https://jsonplaceholder.typicode.com/albums/{id}";
            var response = await HttpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var resultString = await response.Content.ReadAsStringAsync();
                var album = JsonConvert.DeserializeObject<Album>(resultString);
                return album;
            }

            throw new HttpResponseException();
        }

        public async Task<IEnumerable<Post>> GetPostsByUserIdAsync(int id)
        {
            var url = $" https://jsonplaceholder.typicode.com/users/{id}/posts";
            var response = await HttpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var resultString = await response.Content.ReadAsStringAsync();
                var posts = JsonConvert.DeserializeObject<IEnumerable<Post>>(resultString);
                return posts;
            }

            throw new HttpResponseException();
        }

    }
}
