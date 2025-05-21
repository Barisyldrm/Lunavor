using System.Threading.Tasks;
using Lunavor.AdminPanel.Services;
using Lunavor.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Lunavor.AdminPanel.Models;

namespace Lunavor.AdminPanel.Controllers
{
    public class BlogsController : Controller
    {
        private readonly IApiService _apiService;

        public BlogsController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var blogs = await _apiService.GetAllBlogsAsync();
            return View(blogs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogModel blog)
        {
            if (!ModelState.IsValid)
            {
                return View(blog);
            }

            var success = await _apiService.CreateBlogAsync(blog);
            if (!success)
            {
                ModelState.AddModelError(string.Empty, "Blog oluşturulurken bir hata oluştu");
                return View(blog);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var blog = await _apiService.GetBlogByIdAsync(id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BlogModel blog)
        {
            if (id != blog.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(blog);
            }

            var success = await _apiService.UpdateBlogAsync(blog);
            if (!success)
            {
                ModelState.AddModelError(string.Empty, "Blog güncellenirken bir hata oluştu");
                return View(blog);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _apiService.DeleteBlogAsync(id);
            if (!success)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }
    }
} 