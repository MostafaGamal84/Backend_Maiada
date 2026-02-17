using System;
using System.Collections.Generic;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class Attendance:EntityBase
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public int EnrollmentId { get; set; }
        public string Status { get; set; } = null!;
        public string? ExcuseReason { get; set; }
        public DateTime? MarkedAt { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Enrollment Enrollment { get; set; } = null!;
        public virtual Session Session { get; set; } = null!;
    }
}
