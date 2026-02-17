using System;
using System.Collections.Generic;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class Session:EntityBase
    {
        public Session()
        {
            Attendances = new HashSet<Attendance>();
            SessionHistories = new HashSet<SessionHistory>();
            SessionPurchas = new HashSet<SessionPurchas>();
        }

        public int Id { get; set; }
        public int CourseInstanceId { get; set; }
        public string? Title { get; set; }
        public int SessionNumber { get; set; }
        public DateTime SessionDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Type { get; set; } = null!;
        public string? Status { get; set; }
        public DateTime? OriginalSessionDate { get; set; }
        public int? ReplacementQuizId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual CourseInstance CourseInstance { get; set; } = null!;
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<SessionHistory> SessionHistories { get; set; }
        public virtual ICollection<SessionPurchas> SessionPurchas { get; set; }
    }
}
