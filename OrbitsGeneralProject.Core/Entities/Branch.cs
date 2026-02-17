using System;
using System.Collections.Generic;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class Branch:EntityBase
    {
        public Branch()
        {
            CourseInstances = new HashSet<CourseInstance>();
            Students = new HashSet<Student>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<CourseInstance> CourseInstances { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
