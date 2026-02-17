using System;
using System.Collections.Generic;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class Enrollment:EntityBase
    {
        public Enrollment()
        {
            Attendances = new HashSet<Attendance>();
            Payments = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseInstanceId { get; set; }
        public string PurchaseType { get; set; } = null!;
        public int? AttendanceCount { get; set; }
        public int? AbsenceCount { get; set; }
        public int? ConsecutiveAbsenceCount { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool IsDeleted { get; set; }

        public virtual CourseInstance CourseInstance { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
