using System.Threading.Tasks;
using Lunavor.AdminPanel.Services;
using Lunavor.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Lunavor.AdminPanel.Models;

namespace Lunavor.AdminPanel.Controllers
{
    public class PortfoliosController : Controller
    {
        private readonly IApiService _apiService;

        public PortfoliosController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var portfolios = await _apiService.GetAllPortfoliosAsync();
            return View(portfolios);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PortfolioModel portfolio)
        {
            if (!ModelState.IsValid)
            {
                return View(portfolio);
            }

            var success = await _apiService.CreatePortfolioAsync(portfolio);
            if (!success)
            {
                ModelState.AddModelError(string.Empty, "Portfolyo oluşturulurken bir hata oluştu");
                return View(portfolio);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var portfolio = await _apiService.GetPortfolioByIdAsync(id);
            if (portfolio == null)
            {
                return NotFound();
            }

            return View(portfolio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PortfolioModel portfolio)
        {
            if (id != portfolio.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(portfolio);
            }

            var success = await _apiService.UpdatePortfolioAsync(portfolio);
            if (!success)
            {
                ModelState.AddModelError(string.Empty, "Portfolyo güncellenirken bir hata oluştu");
                return View(portfolio);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _apiService.DeletePortfolioAsync(id);
            if (!success)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }
    }
} 