using System;
using System.Collections.Generic;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class SessionHistory:EntityBase
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public DateTime? OldDate { get; set; }
        public DateTime? NewDate { get; set; }
        public int? ChangedBy { get; set; }
        public DateTime? ChangedAt { get; set; }
        public string? Reason { get; set; }
        public bool IsDeleted { get; set; }

        public virtual User? ChangedByNavigation { get; set; }
        public virtual Session Session { get; set; } = null!;
    }
}
