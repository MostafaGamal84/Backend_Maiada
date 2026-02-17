using System;
using System.Collections.Generic;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class SessionPurchas:EntityBase
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SessionId { get; set; }
        public decimal Price { get; set; }
        public string? Status { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Session Session { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
    }
}
