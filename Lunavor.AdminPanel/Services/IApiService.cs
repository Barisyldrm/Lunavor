using System.Collections.Generic;
using System.Threading.Tasks;
using Lunavor.AdminPanel.Models;

namespace Lunavor.AdminPanel.Services
{
    public interface IApiService
    {
        // Auth işlemleri
        Task<string?> LoginAsync(LoginViewModel model);

        // Dashboard için metodlar
        Task<int> GetServiceCountAsync();
        Task<int> GetPortfolioCountAsync();
        Task<int> GetBlogCountAsync();
        Task<List<ServiceModel>> GetRecentServicesAsync();
        Task<List<PortfolioModel>> GetRecentPortfoliosAsync();
        Task<List<BlogModel>> GetRecentBlogsAsync();

        // Service işlemleri
        Task<List<ServiceModel>> GetAllServicesAsync();
        Task<ServiceModel> GetServiceByIdAsync(int id);
        Task<bool> CreateServiceAsync(ServiceModel service);
        Task<bool> UpdateServiceAsync(ServiceModel service);
        Task<bool> DeleteServiceAsync(int id);

        // Portfolio işlemleri
        Task<List<PortfolioModel>> GetAllPortfoliosAsync();
        Task<PortfolioModel> GetPortfolioByIdAsync(int id);
        Task<bool> CreatePortfolioAsync(PortfolioModel portfolio);
        Task<bool> UpdatePortfolioAsync(PortfolioModel portfolio);
        Task<bool> DeletePortfolioAsync(int id);

        // Blog işlemleri
        Task<List<BlogModel>> GetAllBlogsAsync();
        Task<BlogModel> GetBlogByIdAsync(int id);
        Task<bool> CreateBlogAsync(BlogModel blog);
        Task<bool> UpdateBlogAsync(BlogModel blog);
        Task<bool> DeleteBlogAsync(int id);

        Task<List<ServiceModel>> GetServicesAsync();
    }
} 