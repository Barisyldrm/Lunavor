using System.ComponentModel.DataAnnotations;

namespace Lunavor.AdminPanel.Models
{
    public class PortfolioViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Başlık zorunludur.")]
        [Display(Name = "Başlık")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Açıklama zorunludur.")]
        [Display(Name = "Açıklama")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Resim URL'si zorunludur.")]
        [Display(Name = "Resim URL")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = "Kategori zorunludur.")]
        [Display(Name = "Kategori")]
        public string Category { get; set; } = string.Empty;

        [Display(Name = "Tamamlanma Tarihi")]
        public DateTime CompletedDate { get; set; } = DateTime.Now;

        [Display(Name = "Aktif")]
        public bool IsActive { get; set; } = true;
    }
} 