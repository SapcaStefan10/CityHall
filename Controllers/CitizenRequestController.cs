using Microsoft.AspNetCore.Mvc;
using SElab5.Models;

namespace SElab5.Controllers
{
    public class CitizenRequestController : Controller
    {
        // GET: /CitizenRequest/Index
        public IActionResult Index()
        {
            // TODO: List requests (REQ-18)
            return View();
        }

        // GET: /CitizenRequest/Submit
        [HttpGet]
        public IActionResult Submit()
        {
            return View();
        }

        // POST: /CitizenRequest/Submit
        [HttpPost]
        public IActionResult Submit(Request request)
        {
            if (ModelState.IsValid)
            {
                // TODO: Save request (REQ-11)
                return RedirectToAction("Index");
            }
            return View(request);
        }

        // GET: /CitizenRequest/Status/{id}
        public IActionResult Status(int id)
        {
            // TODO: Fetch request status (REQ-14)
            return View();
        }

        // POST: /CitizenRequest/Delete/{id}
        public IActionResult Delete(int id)
        {
            // TODO: Delete request (REQ-13)
            return RedirectToAction("Index");
        }
    }
}
