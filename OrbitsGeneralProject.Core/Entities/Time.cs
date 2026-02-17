using System;
using System.Collections.Generic;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class Time:EntityBase
    {
        public Time()
        {
            CircleTimes = new HashSet<CircleTime>();
            ManagerTimes = new HashSet<ManagerTime>();
            StudentTimes = new HashSet<StudentTime>();
            TeacherTimes = new HashSet<TeacherTime>();
        }

        public int Id { get; set; }
        public string? DayName { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<CircleTime> CircleTimes { get; set; }
        public virtual ICollection<ManagerTime> ManagerTimes { get; set; }
        public virtual ICollection<StudentTime> StudentTimes { get; set; }
        public virtual ICollection<TeacherTime> TeacherTimes { get; set; }
    }
}
