using System.ComponentModel.DataAnnotations;

namespace Lunavor.AdminPanel.Models
{
    public class PortfolioModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Başlık alanı zorunludur.")]
        [StringLength(200, ErrorMessage = "Başlık en fazla 200 karakter olabilir.")]
        [Display(Name = "Başlık")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Açıklama alanı zorunludur.")]
        [StringLength(1000, ErrorMessage = "Açıklama en fazla 1000 karakter olabilir.")]
        [Display(Name = "Açıklama")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Resim URL alanı zorunludur.")]
        [Display(Name = "Resim URL")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = "Kategori alanı zorunludur.")]
        [Display(Name = "Kategori")]
        public string Category { get; set; } = string.Empty;

        [Display(Name = "Tamamlanma Tarihi")]
        public DateTime CompletedDate { get; set; } = DateTime.Now;

        [Display(Name = "Aktif")]
        public bool IsActive { get; set; } = true;

        [Display(Name = "Proje URL")]
        public string ProjectUrl { get; set; } = string.Empty;
    }
} 