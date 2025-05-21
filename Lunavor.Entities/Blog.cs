using System;

namespace Lunavor.Entities
{
    public class Blog : BaseEntity
    {
        public required string Title { get; set; }
        public required string Content { get; set; }
        public required string ImageUrl { get; set; }
        public required string Author { get; set; }
        public DateTime PublishDate { get; set; }
        public required string Category { get; set; }
        public required string Tags { get; set; }
    }
} 