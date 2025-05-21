using System.ComponentModel.DataAnnotations;

namespace Lunavor.AdminPanel.Models
{
    public class BlogViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Başlık zorunludur.")]
        [Display(Name = "Başlık")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Özet zorunludur.")]
        [Display(Name = "Özet")]
        public string Summary { get; set; } = string.Empty;

        [Required(ErrorMessage = "Resim URL'si zorunludur.")]
        [Display(Name = "Resim URL")]
        public string ImageUrl { get; set; } = string.Empty;

        [Display(Name = "Oluşturulma Tarihi")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "Aktif")]
        public bool IsActive { get; set; } = true;
    }
} 