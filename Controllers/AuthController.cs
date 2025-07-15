using blog.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace blog.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AuthController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet("login")]
        public IActionResult LoginPage()
        {
            return View();
        }

        [HttpGet("register")]
        public IActionResult RegisterPage()
        {
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] string email, [FromForm] string password, [FromQuery] string ReturnUrl = "/")
        {
            var user = await _userManager.FindByEmailAsync(email);
            
            if (user == null)
                return Unauthorized("User not found");

            var result = await _signInManager.PasswordSignInAsync(user, password, isPersistent: false, lockoutOnFailure: false);

            if (!result.Succeeded)
                return Unauthorized("Incorrect username or password");

            return Redirect(ReturnUrl);

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] string email, [FromForm] string password, [FromQuery] string ReturnUrl = "/")
        {
            var user = new User { UserName = email, Email = email };
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded) 
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return Redirect("/");
            }

            return Unauthorized(result.Errors);
        }
    }
}
