using System.ComponentModel.DataAnnotations;

namespace Lunavor.AdminPanel.Models
{
    public class ServiceModel
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

        [Required(ErrorMessage = "İkon alanı zorunludur.")]
        [Display(Name = "İkon")]
        public string Icon { get; set; } = string.Empty;

        [Display(Name = "Özellikler")]
        public List<string> Features { get; set; } = new List<string>();

        [Display(Name = "Sıralama")]
        public int Order { get; set; }

        [Display(Name = "Oluşturulma Tarihi")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "Aktif")]
        public bool IsActive { get; set; } = true;
    }
} 