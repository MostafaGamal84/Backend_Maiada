using System;
using System.Collections.Generic;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class Student:EntityBase
    {
        public Student()
        {
            CircleStudents = new HashSet<CircleStudent>();
            ManagerStudents = new HashSet<ManagerStudent>();
            PayScreenShots = new HashSet<PayScreenShot>();
            StudentReports = new HashSet<StudentReport>();
            StudentTimes = new HashSet<StudentTime>();
            TeacherStudents = new HashSet<TeacherStudent>();
        }

        public int Id { get; set; }
        public int Age { get; set; }
        public int? NationalityId { get; set; }
        public int? GovernorateId { get; set; }
        public int? InsteadMobileNumber { get; set; }
        public int? SubscribeId { get; set; }
        public int? PayStatueId { get; set; }
        public int? FamilyId { get; set; }
        public bool FreeCircle { get; set; }
        public string? PhotoUrl { get; set; }
        public int? SavedParts { get; set; }
        public double? Count { get; set; }

        public virtual Family? Family { get; set; }
        public virtual Governorate? Governorate { get; set; }
        public virtual AspNetUser IdNavigation { get; set; } = null!;
        public virtual Nationality? Nationality { get; set; }
        public virtual PayStatue? PayStatue { get; set; }
        public virtual Subscribe? Subscribe { get; set; }
        public virtual ICollection<CircleStudent> CircleStudents { get; set; }
        public virtual ICollection<ManagerStudent> ManagerStudents { get; set; }
        public virtual ICollection<PayScreenShot> PayScreenShots { get; set; }
        public virtual ICollection<StudentReport> StudentReports { get; set; }
        public virtual ICollection<StudentTime> StudentTimes { get; set; }
        public virtual ICollection<TeacherStudent> TeacherStudents { get; set; }
    }
}
