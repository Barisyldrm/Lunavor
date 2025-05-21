using System;
using System.ComponentModel.DataAnnotations;

namespace Lunavor.WebUI.Models
{
    public class ServiceViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Başlık alanı zorunludur")]
        [Display(Name = "Başlık")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Açıklama alanı zorunludur")]
        [Display(Name = "Açıklama")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "İkon")]
        public string Icon { get; set; } = string.Empty;

        [Display(Name = "Sıralama")]
        public int DisplayOrder { get; set; }

        [Display(Name = "Aktif")]
        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }
    }
} 