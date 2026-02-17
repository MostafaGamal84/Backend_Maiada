using System;
using System.Collections.Generic;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class SmsLog:EntityBase
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string? Message { get; set; }
        public DateTime? SentAt { get; set; }
        public string? Status { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Student Student { get; set; } = null!;
    }
}
