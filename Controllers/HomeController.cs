using Microsoft.AspNetCore.Mvc;
using CityHallManagement.Models;
using System.Diagnostics;
using CityHallManagement.Services.Interfaces;

namespace CityHallManagement.Controllers
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

