using System;
using System.Collections.Generic;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class Teacher:EntityBase
    {
        public Teacher()
        {
            HoursRecords = new HashSet<HoursRecord>();
            ManagerTeachers = new HashSet<ManagerTeacher>();
            StudentReports = new HashSet<StudentReport>();
            TeacherCircles = new HashSet<TeacherCircle>();
            TeacherHours = new HashSet<TeacherHour>();
            TeacherStudents = new HashSet<TeacherStudent>();
            TeacherTimes = new HashSet<TeacherTime>();
        }

        public int Id { get; set; }
        public bool? ForignTeacher { get; set; }
        public int? GovernorateId { get; set; }

        public virtual Governorate? Governorate { get; set; }
        public virtual AspNetUser IdNavigation { get; set; } = null!;
        public virtual ICollection<HoursRecord> HoursRecords { get; set; }
        public virtual ICollection<ManagerTeacher> ManagerTeachers { get; set; }
        public virtual ICollection<StudentReport> StudentReports { get; set; }
        public virtual ICollection<TeacherCircle> TeacherCircles { get; set; }
        public virtual ICollection<TeacherHour> TeacherHours { get; set; }
        public virtual ICollection<TeacherStudent> TeacherStudents { get; set; }
        public virtual ICollection<TeacherTime> TeacherTimes { get; set; }
    }
}
