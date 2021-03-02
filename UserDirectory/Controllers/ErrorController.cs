using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UserDirectory.Infrastructure;

namespace UserDirectory.Controllers
{
    public class ErrorController : Controller
    {

        public ViewResult Error()
        {
            return View();
        }
    }
}
