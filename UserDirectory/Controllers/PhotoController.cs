using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using UserDirectory.BusinessLayer;
using UserDirectory.Infrastructure;
using UserDirectory.Models.ViewModels;
using UserDirectory.Repository;

namespace UserDirectory.Controllers
{
    [HttpResponseException]
    public class PhotoController : Controller
    {
        private readonly IAlbumService _service;

        public PhotoController(IAlbumService service)
        {
            _service = service;
        }

        public async Task<IActionResult> List(int id, string returnUrl)
        {
            var repo = new JsonplaceholderRepository();
            var photos = await _service.GetPhotosByAlbumIdAsync(id);
            var album = await _service.GetAlbumByIdAsync(id);

            var result = new PhotoAlbumViewModel()
            {
                Photos = photos.Select(t => new PhotoViewModel()
                {
                    ThumbnailUrl = t.ThumbnailUrl,
                    Title = t.Title
                }),
                AlbumTitle = album?.Title, 
                ReturnUrl = returnUrl
            };

            return View(result);
        }
    }
}
