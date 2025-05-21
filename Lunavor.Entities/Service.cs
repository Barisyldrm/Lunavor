using System;
// using Lunavor.Core.Entities; // BaseEntity'nin doğru ad alanı
using Lunavor.Entities; // BaseEntity kendi ad alanında

namespace Lunavor.Entities
{
    public class Service : BaseEntity
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Icon { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
    }
} 