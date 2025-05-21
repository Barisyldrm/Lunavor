using System;
using System.Threading.Tasks;
using Lunavor.AdminPanel.Services;
using Lunavor.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lunavor.AdminPanel.Models;

namespace Lunavor.AdminPanel.Controllers
{
    [Authorize]
    public class ServicesController : Controller
    {
        private readonly ApiService _apiService;
        private readonly ILogger<ServicesController> _logger;

        public ServicesController(ApiService apiService, ILogger<ServicesController> logger)
        {
            _apiService = apiService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var services = await _apiService.GetServicesAsync();
                return View(services);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Hizmetler listelenirken hata oluştu");
                return View("Error");
            }
        }

        public IActionResult Create()
        {
            return View(new ServiceModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceModel model)
        {
            if (ModelState.IsValid)
            {
                await _apiService.CreateServiceAsync(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var service = await _apiService.GetServiceByIdAsync(id);
                if (service == null)
                {
                    return NotFound();
                }
                return View(service);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Hizmet düzenleme sayfası yüklenirken hata oluştu");
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ServiceModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _apiService.UpdateServiceAsync(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _apiService.DeleteServiceAsync(id);
                TempData["Success"] = "Hizmet başarıyla silindi.";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Hizmet silinirken hata oluştu");
                TempData["Error"] = "Hizmet silinirken bir hata oluştu: " + ex.Message;
            }

            return RedirectToAction(nameof(Index));
        }
    }
} 