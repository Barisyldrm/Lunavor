using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Lunavor.AdminPanel.Services;
using Lunavor.AdminPanel.Models;

namespace Lunavor.AdminPanel.Controllers
{
    [Authorize]
    public class ServiceController(IApiService apiService) : Controller
    {
        private readonly IApiService _apiService = apiService;

        public async Task<IActionResult> Index()
        {
            var services = await _apiService.GetAllServicesAsync();
            return View(services);
        }

        public IActionResult Create()
        {
            return View(new ServiceModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _apiService.CreateServiceAsync(model);
            if (!result)
            {
                ModelState.AddModelError("", "Hizmet oluşturulurken bir hata oluştu.");
                return View(model);
            }

            TempData["Success"] = "Hizmet başarıyla oluşturuldu.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var service = await _apiService.GetServiceByIdAsync(id);
            return service == null ? NotFound() : View(service);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ServiceModel model)
        {
            if (id != model.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(model);

            var result = await _apiService.UpdateServiceAsync(model);
            if (!result)
            {
                ModelState.AddModelError("", "Hizmet güncellenirken bir hata oluştu.");
                return View(model);
            }

            TempData["Success"] = "Hizmet başarıyla güncellendi.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _apiService.DeleteServiceAsync(id);
            TempData[result ? "Success" : "Error"] = result 
                ? "Hizmet başarıyla silindi." 
                : "Hizmet silinirken bir hata oluştu.";
            
            return RedirectToAction(nameof(Index));
        }
    }
} 