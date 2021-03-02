using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserDirectory.BusinessLayer;
using UserDirectory.Infrastructure;
using UserDirectory.Models.ViewModels;

namespace UserDirectory.Controllers
{
    [HttpResponseException]
    public class UserController : Controller
    {
        private readonly IAlbumService _service;

        public UserController(IAlbumService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(int id, string returnUrl)
        {
            var user = await _service.GetUserByIdAsync(id);
            var userPosts = await _service.GetPostsByUserIdAsync(id);
            
            var result = new UserInfoViewModel()
            {
                Posts = userPosts,
                UserInfo = user,
                ReturnUrl = returnUrl
            };
            return View(result);
        }
    }
}
