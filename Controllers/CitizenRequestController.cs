using Microsoft.AspNetCore.Mvc;
using SElab5.Models;
using SElab5.Services.Interfaces;

namespace SElab5.Controllers
{
    public class CitizenRequestController : Controller
    {
        private readonly IRequestService _requestService;

        public CitizenRequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        // GET: /CitizenRequest/Index
        public async Task<IActionResult> Index()
        {
            var role = HttpContext.Session.GetString("UserRole");
            var userId = HttpContext.Session.GetInt32("UserID") ?? 1;

            if (role == "Admin")
            {
                var allRequests = await _requestService.GetAllRequestsAsync(); // Need to implement this
                return View(allRequests);
            }

            var requests = await _requestService.GetUserRequestsAsync(userId);
            return View(requests);
        }

        // GET: /CitizenRequest/Submit
        [HttpGet]
        public IActionResult Submit()
        {
            return View();
        }

        // POST: /CitizenRequest/Submit
        [HttpPost]
        public async Task<IActionResult> Submit(Request request)
        {
            if (ModelState.IsValid)
            {
                var userId = HttpContext.Session.GetInt32("UserID") ?? 1;
                request.CitizenID = userId;
                var success = await _requestService.SubmitRequestAsync(request);
                if (success)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(request);
        }

        // GET: /CitizenRequest/Status/{id}
        public async Task<IActionResult> Status(int id)
        {
            var request = await _requestService.GetRequestByIdAsync(id);
            if (request == null) return NotFound();
            return View(request);
        }

        // POST: /CitizenRequest/Delete/{id}
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _requestService.DeleteRequestAsync(id);
            return RedirectToAction("Index");
        }
    }
}

