using System;
using System.Collections.Generic;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class StudentQuizAttempt:EntityBase
    {
        public StudentQuizAttempt()
        {
            StudentAnswers = new HashSet<StudentAnswer>();
        }

        public int Id { get; set; }
        public int QuizId { get; set; }
        public int StudentId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? Score { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Quizze Quiz { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
        public virtual ICollection<StudentAnswer> StudentAnswers { get; set; }
    }
}
