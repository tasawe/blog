using Microsoft.AspNetCore.Mvc;

namespace blog.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
    }
}
