using System;
using System.Collections.Generic;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class Student:EntityBase
    {
        public Student()
        {
            Enrollments = new HashSet<Enrollment>();
            SessionPurchas = new HashSet<SessionPurchas>();
            SmsLogs = new HashSet<SmsLog>();
            StudentQuizAttempts = new HashSet<StudentQuizAttempt>();
        }

        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string? Mobile { get; set; }
        public string? ParentMobile { get; set; }
        public string? NationalId { get; set; }
        public string UniqueCode { get; set; } = null!;
        public int BranchId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Branch Branch { get; set; } = null!;
        public virtual Wallet Wallet { get; set; } = null!;
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<SessionPurchas> SessionPurchas { get; set; }
        public virtual ICollection<SmsLog> SmsLogs { get; set; }
        public virtual ICollection<StudentQuizAttempt> StudentQuizAttempts { get; set; }
    }
}
