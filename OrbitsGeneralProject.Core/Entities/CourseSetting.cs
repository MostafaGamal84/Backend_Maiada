using System;
using System.Collections.Generic;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class CourseSetting:EntityBase
    {
        public int Id { get; set; }
        public int CourseInstanceId { get; set; }
        public int AbsenceLimit { get; set; }
        public string AbsenceType { get; set; } = null!;
        public int ReminderBeforeHours { get; set; }
        public bool? AllowReschedule { get; set; }
        public bool? AllowReplaceWithQuiz { get; set; }
        public bool? AutoDismissEnabled { get; set; }
        public string? RefundPolicy { get; set; }
        public bool IsDeleted { get; set; }

        public virtual CourseInstance CourseInstance { get; set; } = null!;
    }
}
