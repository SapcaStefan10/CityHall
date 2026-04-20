using Microsoft.AspNetCore.Mvc;
using SElab5.Models;

namespace SElab5.Controllers
{
    public class AdminController : Controller
    {
        // GET: /Admin/Dashboard
        public IActionResult Dashboard()
        {
            // TODO: Fetch dashboard statistics (REQ-67)
            return View();
        }

        // GET: /Admin/Departments
        public IActionResult Departments()
        {
            // TODO: List departments (REQ-29)
            return View();
        }

        // GET: /Admin/CreateDepartment
        [HttpGet]
        public IActionResult CreateDepartment()
        {
            return View();
        }

        // POST: /Admin/CreateDepartment
        [HttpPost]
        public IActionResult CreateDepartment(Department department)
        {
            if (ModelState.IsValid)
            {
                // TODO: Save department (REQ-21)
                return RedirectToAction("Departments");
            }
            return View(department);
        }

        // GET: /Admin/Employees
        public IActionResult Employees()
        {
            // TODO: List employees (REQ-29)
            return View();
        }

        // GET: /Admin/OrgChart
        public IActionResult OrgChart()
        {
            // TODO: Visualize org chart (REQ-24)
            return View();
        }
    }
}
