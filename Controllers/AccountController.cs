using Microsoft.AspNetCore.Mvc;

namespace blog.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        [Route("/login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        [Route("/register")]
        public IActionResult Register()
        {
            return View();
        }
    }
}
