using System;
// using Lunavor.Core.Entities; // BaseEntity'nin doğru ad alanı
using Lunavor.Entities; // BaseEntity kendi ad alanında
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lunavor.Entities
{
    public class User : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        [StringLength(20)]
        public string Role { get; set; } = "User"; // Default role

        public bool IsActive { get; set; } = true;

        // Navigation property for related data (e.g., Blog posts created by user)
        public virtual ICollection<Blog>? Blogs { get; set; }
    }
} 