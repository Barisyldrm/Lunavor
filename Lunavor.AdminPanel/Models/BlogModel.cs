using System.ComponentModel.DataAnnotations;

namespace Lunavor.AdminPanel.Models
{
    public class BlogModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Başlık alanı zorunludur.")]
        [StringLength(200, ErrorMessage = "Başlık en fazla 200 karakter olabilir.")]
        [Display(Name = "Başlık")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Özet alanı zorunludur.")]
        [StringLength(500, ErrorMessage = "Özet en fazla 500 karakter olabilir.")]
        [Display(Name = "Özet")]
        public string Summary { get; set; } = string.Empty;

        [Required(ErrorMessage = "İçerik alanı zorunludur.")]
        [Display(Name = "İçerik")]
        public string Content { get; set; } = string.Empty;

        [Required(ErrorMessage = "Resim URL alanı zorunludur.")]
        [Display(Name = "Resim URL")]
        public string ImageUrl { get; set; } = string.Empty;

        [Display(Name = "Oluşturulma Tarihi")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "Aktif")]
        public bool IsActive { get; set; } = true;
    }
} 