using System.Net.Http.Json;
using Lunavor.WebUI.Models;

namespace Lunavor.WebUI.Services
{
    public interface IApiService
    {
        Task<IEnumerable<ServiceViewModel>> GetServicesAsync();
        Task<ServiceViewModel?> GetServiceByIdAsync(int id);
        Task<bool> CreateServiceAsync(ServiceViewModel service);
        Task<bool> UpdateServiceAsync(ServiceViewModel service);
        Task<bool> DeleteServiceAsync(int id);
    }

    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ApiService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            
            var baseUrl = _configuration["ApiSettings:BaseUrl"] ?? "http://localhost:7137";
            _httpClient.BaseAddress = new Uri(baseUrl);
        }

        public async Task<IEnumerable<ServiceViewModel>> GetServicesAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<IEnumerable<ServiceViewModel>>("api/services");
            return response ?? Enumerable.Empty<ServiceViewModel>();
        }

        public async Task<ServiceViewModel?> GetServiceByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<ServiceViewModel>($"api/services/{id}");
        }

        public async Task<bool> CreateServiceAsync(ServiceViewModel service)
        {
            var response = await _httpClient.PostAsJsonAsync("api/services", service);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateServiceAsync(ServiceViewModel service)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/services/{service.Id}", service);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteServiceAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/services/{id}");
            return true;
        }
    }
} 