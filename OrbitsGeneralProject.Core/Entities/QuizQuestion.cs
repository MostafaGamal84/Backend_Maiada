using System;
using System.Collections.Generic;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class QuizQuestion:EntityBase
    {
        public QuizQuestion()
        {
            QuestionChoices = new HashSet<QuestionChoice>();
            StudentAnswers = new HashSet<StudentAnswer>();
        }

        public int Id { get; set; }
        public int QuizId { get; set; }
        public string QuestionText { get; set; } = null!;
        public string? Explanation { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Quizze Quiz { get; set; } = null!;
        public virtual ICollection<QuestionChoice> QuestionChoices { get; set; }
        public virtual ICollection<StudentAnswer> StudentAnswers { get; set; }
    }
}
