using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Lunavor.AdminPanel.Models;
using Lunavor.AdminPanel.Services;

namespace Lunavor.AdminPanel.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IApiService _apiService;

    public HomeController(ILogger<HomeController> logger, IApiService apiService)
    {
        _logger = logger;
        _apiService = apiService;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            var viewModel = new DashboardViewModel
            {
                ServiceCount = await _apiService.GetServiceCountAsync(),
                PortfolioCount = await _apiService.GetPortfolioCountAsync(),
                BlogCount = await _apiService.GetBlogCountAsync(),
                RecentServices = await _apiService.GetRecentServicesAsync(),
                RecentPortfolios = await _apiService.GetRecentPortfoliosAsync(),
                RecentBlogs = await _apiService.GetRecentBlogsAsync()
            };

            return View(viewModel);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Dashboard verileri alınırken hata oluştu");
            return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [AllowAnonymous]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
