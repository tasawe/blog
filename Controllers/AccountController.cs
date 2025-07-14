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
    }
}
