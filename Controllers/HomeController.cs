using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace blog.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        [HttpGet("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
