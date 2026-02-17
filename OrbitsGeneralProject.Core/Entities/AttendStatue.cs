using System;
using System.Collections.Generic;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class AttendStatue:EntityBase
    {
        public AttendStatue()
        {
            StudentReports = new HashSet<StudentReport>();
            TeacherHours = new HashSet<TeacherHour>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<StudentReport> StudentReports { get; set; }
        public virtual ICollection<TeacherHour> TeacherHours { get; set; }
    }
}
