using System;
using System.Collections.Generic;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class Circle:EntityBase
    {
        public Circle()
        {
            CircleManagers = new HashSet<CircleManager>();
            CircleStudents = new HashSet<CircleStudent>();
            CircleTimes = new HashSet<CircleTime>();
            StudentReports = new HashSet<StudentReport>();
            TeacherCircles = new HashSet<TeacherCircle>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<CircleManager> CircleManagers { get; set; }
        public virtual ICollection<CircleStudent> CircleStudents { get; set; }
        public virtual ICollection<CircleTime> CircleTimes { get; set; }
        public virtual ICollection<StudentReport> StudentReports { get; set; }
        public virtual ICollection<TeacherCircle> TeacherCircles { get; set; }
    }
}
