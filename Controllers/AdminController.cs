using Microsoft.AspNetCore.Mvc;
using SElab5.Models;
using SElab5.Services.Interfaces;

namespace SElab5.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserService _userService;

        public AdminController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _userService.AuthenticateAsync(email, password);
            if (user != null)
            {
                HttpContext.Session.SetInt32("UserID", user.UserID);
                HttpContext.Session.SetString("UserFullName", user.FullName);
                HttpContext.Session.SetString("UserRole", user.Role?.RoleName ?? "Citizen");
                
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Invalid login attempt.");
            return View();
        }

        // GET: /Account/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        public async Task<IActionResult> Register(User user, string password)
        {
            if (ModelState.IsValid)
            {
                var success = await _userService.RegisterAsync(user, password);
                if (success)
                {
                    return RedirectToAction("Login");
                }
                ModelState.AddModelError("Email", "Email already in use.");
            }
            return View(user);
        }

        // GET: /Account/Profile
        public async Task<IActionResult> Profile(int id)
        {
            var user = await _userService.GetUserProfileAsync(id);
            if (user == null) return NotFound();
            return View(user);
        }

        // GET: /Account/Logout
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}

