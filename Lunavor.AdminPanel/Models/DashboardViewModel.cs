using System.Collections.Generic;

namespace Lunavor.AdminPanel.Models
{
    public class DashboardViewModel
    {
        public int ServiceCount { get; set; }
        public int PortfolioCount { get; set; }
        public int BlogCount { get; set; }
        public List<ServiceModel> RecentServices { get; set; } = new List<ServiceModel>();
        public List<PortfolioModel> RecentPortfolios { get; set; } = new List<PortfolioModel>();
        public List<BlogModel> RecentBlogs { get; set; } = new List<BlogModel>();
    }
} 