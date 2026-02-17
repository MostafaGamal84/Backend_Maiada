using System;
using System.Collections.Generic;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class Quizze:EntityBase
    {
        public Quizze()
        {
            QuizQuestions = new HashSet<QuizQuestion>();
            StudentQuizAttempts = new HashSet<StudentQuizAttempt>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int TotalScore { get; set; }
        public int DurationMinutes { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<QuizQuestion> QuizQuestions { get; set; }
        public virtual ICollection<StudentQuizAttempt> StudentQuizAttempts { get; set; }
    }
}
