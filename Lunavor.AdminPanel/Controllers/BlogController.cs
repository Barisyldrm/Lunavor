using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Lunavor.AdminPanel.Services;
using Lunavor.AdminPanel.Models;

namespace Lunavor.AdminPanel.Controllers
{
    [Authorize]
    public class BlogController(IApiService apiService) : Controller
    {
        private readonly IApiService _apiService = apiService;

        public async Task<IActionResult> Index()
        {
            var blogs = await _apiService.GetAllBlogsAsync();
            return View(blogs);
        }

        public IActionResult Create()
        {
            return View(new BlogModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _apiService.CreateBlogAsync(model);
            if (!result)
            {
                ModelState.AddModelError("", "Blog yazısı oluşturulurken bir hata oluştu.");
                return View(model);
            }

            TempData["Success"] = "Blog yazısı başarıyla oluşturuldu.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var blog = await _apiService.GetBlogByIdAsync(id);
            return blog == null ? NotFound() : View(blog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BlogModel model)
        {
            if (id != model.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(model);

            var result = await _apiService.UpdateBlogAsync(model);
            if (!result)
            {
                ModelState.AddModelError("", "Blog yazısı güncellenirken bir hata oluştu.");
                return View(model);
            }

            TempData["Success"] = "Blog yazısı başarıyla güncellendi.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _apiService.DeleteBlogAsync(id);
            TempData[result ? "Success" : "Error"] = result 
                ? "Blog yazısı başarıyla silindi." 
                : "Blog yazısı silinirken bir hata oluştu.";
            
            return RedirectToAction(nameof(Index));
        }
    }
} 