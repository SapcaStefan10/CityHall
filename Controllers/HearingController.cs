using Microsoft.AspNetCore.Mvc;
using SElab5.Models;
using SElab5.Services.Interfaces;

namespace SElab5.Controllers
{
    public class HearingController : Controller
    {
        private readonly IHearingService _hearingService;

        public HearingController(IHearingService hearingService)
        {
            _hearingService = hearingService;
        }

        public async Task<IActionResult> Index()
        {
            var role = HttpContext.Session.GetString("UserRole");
            var userId = HttpContext.Session.GetInt32("UserID") ?? 1;

            if (role == "Admin")
            {
                var allHearings = await _hearingService.GetAllHearingsAsync(); // Need to implement
                return View(allHearings);
            }

            var hearings = await _hearingService.GetUserHearingsAsync(userId);
            return View(hearings);
        }

        [HttpGet]
        public IActionResult Schedule()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Schedule(Hearing hearing)
        {
            if (ModelState.IsValid)
            {
                var userId = HttpContext.Session.GetInt32("UserID") ?? 1;
                hearing.CitizenID = userId;
                hearing.EmployeeID = 1; // Mock employee
                var success = await _hearingService.ScheduleHearingAsync(hearing);
                if (success) return RedirectToAction("Index");
            }
            return View(hearing);
        }
    }
}

