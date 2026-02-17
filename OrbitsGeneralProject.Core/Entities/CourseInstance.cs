using System;
using System.Collections.Generic;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class CourseInstance:EntityBase
    {
        public CourseInstance()
        {
            Enrollments = new HashSet<Enrollment>();
            Sessions = new HashSet<Session>();
        }

        public int Id { get; set; }
        public int CourseTemplateId { get; set; }
        public int BranchId { get; set; }
        public int? TeacherId { get; set; }
        public int TotalSessions { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Branch Branch { get; set; } = null!;
        public virtual CourseTemplate CourseTemplate { get; set; } = null!;
        public virtual User? Teacher { get; set; }
        public virtual CourseSetting CourseSetting { get; set; } = null!;
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
