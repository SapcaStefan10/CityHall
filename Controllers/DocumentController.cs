using Microsoft.AspNetCore.Mvc;
using CityHallManagement.Models;
using CityHallManagement.Services.Interfaces;

namespace CityHallManagement.Controllers
{
    public class DocumentController : Controller
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        public async Task<IActionResult> Index()
        {
            var role = HttpContext.Session.GetString("UserRole");
            var userId = HttpContext.Session.GetInt32("UserID") ?? 1;

            if (role == "Admin")
            {
                var allDocs = await _documentService.GetAllDocumentsAsync(); // Need to implement
                return View(allDocs);
            }

            var docs = await _documentService.GetUserDocumentsAsync(userId);
            return View(docs);
        }

        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(Document document, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var userId = HttpContext.Session.GetInt32("UserID") ?? 1;
                
                // Create uploads folder if not exists
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);

                var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                document.FileName = file.FileName;
                document.FilePath = "uploads/" + fileName;
                document.OwnerID = userId;

                var success = await _documentService.UploadDocumentAsync(document);
                if (success) return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Please select a file to upload.");
            return View(document);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _documentService.DeleteDocumentAsync(id);
            return RedirectToAction("Index");
        }
    }
}

