using System;
using System.Collections.Generic;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class User:EntityBase
    {
        public User()
        {
            CourseInstances = new HashSet<CourseInstance>();
            SessionHistories = new HashSet<SessionHistory>();
        }

        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public string Role { get; set; } = null!;
        public int? BranchId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Branch? Branch { get; set; }
        public virtual ICollection<CourseInstance> CourseInstances { get; set; }
        public virtual ICollection<SessionHistory> SessionHistories { get; set; }
    }
}
