using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Lunavor.AdminPanel.Models;

namespace Lunavor.AdminPanel.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _baseUrl;

        public ApiService(
            HttpClient httpClient, 
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            _baseUrl = _configuration["ApiSettings:BaseUrl"] ?? throw new ArgumentNullException("ApiSettings:BaseUrl");
            
            _httpClient.BaseAddress = new Uri(_baseUrl);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.Timeout = TimeSpan.FromSeconds(30);
        }

        private void AddAuthHeader()
        {
            var token = _httpContextAccessor.HttpContext?.Request.Cookies["AuthToken"];
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }

        public async Task<string?> LoginAsync(LoginViewModel model)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/auth/login", model);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
                    return result?.Token;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        // Dashboard için metodlar
        public async Task<int> GetServiceCountAsync()
        {
            AddAuthHeader();
            var response = await _httpClient.GetFromJsonAsync<int>("api/services/count");
            return response;
        }

        public async Task<int> GetPortfolioCountAsync()
        {
            AddAuthHeader();
            var response = await _httpClient.GetFromJsonAsync<int>("api/portfolios/count");
            return response;
        }

        public async Task<int> GetBlogCountAsync()
        {
            AddAuthHeader();
            var response = await _httpClient.GetFromJsonAsync<int>("api/blogs/count");
            return response;
        }

        public async Task<List<ServiceModel>> GetRecentServicesAsync()
        {
            AddAuthHeader();
            var response = await _httpClient.GetFromJsonAsync<List<ServiceModel>>("api/services/recent");
            return response ?? new List<ServiceModel>();
        }

        public async Task<List<PortfolioModel>> GetRecentPortfoliosAsync()
        {
            AddAuthHeader();
            var response = await _httpClient.GetFromJsonAsync<List<PortfolioModel>>("api/portfolios/recent");
            return response ?? new List<PortfolioModel>();
        }

        public async Task<List<BlogModel>> GetRecentBlogsAsync()
        {
            AddAuthHeader();
            var response = await _httpClient.GetFromJsonAsync<List<BlogModel>>("api/blogs/recent");
            return response ?? new List<BlogModel>();
        }

        // Service işlemleri
        public async Task<List<ServiceModel>> GetAllServicesAsync()
        {
            AddAuthHeader();
            var response = await _httpClient.GetFromJsonAsync<List<ServiceModel>>("api/services");
            return response ?? new List<ServiceModel>();
        }

        public async Task<ServiceModel> GetServiceByIdAsync(int id)
        {
            AddAuthHeader();
            var response = await _httpClient.GetFromJsonAsync<ServiceModel>($"api/services/{id}");
            return response ?? throw new Exception("Hizmet bulunamadı.");
        }

        public async Task<bool> CreateServiceAsync(ServiceModel service)
        {
            AddAuthHeader();
            var response = await _httpClient.PostAsJsonAsync("api/services", service);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateServiceAsync(ServiceModel service)
        {
            AddAuthHeader();
            var response = await _httpClient.PutAsJsonAsync($"api/services/{service.Id}", service);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteServiceAsync(int id)
        {
            AddAuthHeader();
            await _httpClient.DeleteAsync($"api/services/{id}");
            return true;
        }

        // Portfolio işlemleri
        public async Task<List<PortfolioModel>> GetAllPortfoliosAsync()
        {
            AddAuthHeader();
            var response = await _httpClient.GetFromJsonAsync<List<PortfolioModel>>("api/portfolios");
            return response ?? new List<PortfolioModel>();
        }

        public async Task<PortfolioModel> GetPortfolioByIdAsync(int id)
        {
            AddAuthHeader();
            var response = await _httpClient.GetFromJsonAsync<PortfolioModel>($"api/portfolios/{id}");
            return response ?? throw new Exception("Proje bulunamadı.");
        }

        public async Task<bool> CreatePortfolioAsync(PortfolioModel portfolio)
        {
            AddAuthHeader();
            var response = await _httpClient.PostAsJsonAsync("api/portfolios", portfolio);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdatePortfolioAsync(PortfolioModel portfolio)
        {
            AddAuthHeader();
            var response = await _httpClient.PutAsJsonAsync($"api/portfolios/{portfolio.Id}", portfolio);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeletePortfolioAsync(int id)
        {
            AddAuthHeader();
            await _httpClient.DeleteAsync($"api/portfolios/{id}");
            return true;
        }

        // Blog işlemleri
        public async Task<List<BlogModel>> GetAllBlogsAsync()
        {
            AddAuthHeader();
            var response = await _httpClient.GetFromJsonAsync<List<BlogModel>>("api/blogs");
            return response ?? new List<BlogModel>();
        }

        public async Task<BlogModel> GetBlogByIdAsync(int id)
        {
            AddAuthHeader();
            var response = await _httpClient.GetFromJsonAsync<BlogModel>($"api/blogs/{id}");
            return response ?? throw new Exception("Blog yazısı bulunamadı.");
        }

        public async Task<bool> CreateBlogAsync(BlogModel blog)
        {
            AddAuthHeader();
            var response = await _httpClient.PostAsJsonAsync("api/blogs", blog);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateBlogAsync(BlogModel blog)
        {
            AddAuthHeader();
            var response = await _httpClient.PutAsJsonAsync($"api/blogs/{blog.Id}", blog);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteBlogAsync(int id)
        {
            AddAuthHeader();
            await _httpClient.DeleteAsync($"api/blogs/{id}");
            return true;
        }

        public async Task<List<ServiceModel>> GetServicesAsync()
        {
            AddAuthHeader();
            var response = await _httpClient.GetFromJsonAsync<List<ServiceModel>>("api/services");
            return response ?? new List<ServiceModel>();
        }
    }
} 