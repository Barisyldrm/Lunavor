using System;

namespace Lunavor.Entities
{
    public class Portfolio : BaseEntity
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string ImageUrl { get; set; }
        public required string ClientName { get; set; }
        public DateTime ProjectDate { get; set; }
        public required string Category { get; set; }
    }
} 