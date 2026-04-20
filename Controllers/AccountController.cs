using Microsoft.AspNetCore.Mvc;
using SElab5.Models;

namespace SElab5.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            // TODO: Implement authentication logic (REQ-2)
            // 1. Check if user exists in DB
            // 2. Validate password hash
            // 3. Create session/cookie
            return RedirectToAction("Dashboard", "Home");
        }

        // GET: /Account/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                // TODO: Implement registration logic (REQ-1)
                // 1. Hash password
                // 2. Save user to DB
                return RedirectToAction("Login");
            }
            return View(user);
        }

        // GET: /Account/Profile
        public IActionResult Profile()
        {
            // TODO: Fetch user profile (REQ-7)
            return View();
        }

        // POST: /Account/Logout
        public IActionResult Logout()
        {
            // TODO: Clear session (REQ-5)
            return RedirectToAction("Index", "Home");
        }
    }
}
