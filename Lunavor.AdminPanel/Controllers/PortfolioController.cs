using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Lunavor.AdminPanel.Services;
using Lunavor.AdminPanel.Models;

namespace Lunavor.AdminPanel.Controllers
{
    [Authorize]
    public class PortfolioController(IApiService apiService) : Controller
    {
        private readonly IApiService _apiService = apiService;

        public async Task<IActionResult> Index()
        {
            var portfolios = await _apiService.GetAllPortfoliosAsync();
            return View(portfolios);
        }

        public IActionResult Create()
        {
            return View(new PortfolioModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PortfolioModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _apiService.CreatePortfolioAsync(model);
            if (!result)
            {
                ModelState.AddModelError("", "Proje oluşturulurken bir hata oluştu.");
                return View(model);
            }

            TempData["Success"] = "Proje başarıyla oluşturuldu.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var portfolio = await _apiService.GetPortfolioByIdAsync(id);
            return portfolio == null ? NotFound() : View(portfolio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PortfolioModel model)
        {
            if (id != model.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(model);

            var result = await _apiService.UpdatePortfolioAsync(model);
            if (!result)
            {
                ModelState.AddModelError("", "Proje güncellenirken bir hata oluştu.");
                return View(model);
            }

            TempData["Success"] = "Proje başarıyla güncellendi.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _apiService.DeletePortfolioAsync(id);
            TempData[result ? "Success" : "Error"] = result 
                ? "Proje başarıyla silindi." 
                : "Proje silinirken bir hata oluştu.";
            
            return RedirectToAction(nameof(Index));
        }
    }
} 