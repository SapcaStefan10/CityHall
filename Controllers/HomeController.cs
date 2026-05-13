using Microsoft.AspNetCore.Mvc;
using SElab5.Models;
using System.Diagnostics;
using SElab5.Services.Interfaces;

namespace SElab5.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public HomeController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public async Task<IActionResult> Index()
        {
            var stats = await _departmentService.GetDashboardStatsAsync();
            ViewBag.Stats = stats;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

