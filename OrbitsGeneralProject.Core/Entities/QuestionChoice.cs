using System;
using System.Collections.Generic;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class QuestionChoice:EntityBase
    {
        public QuestionChoice()
        {
            StudentAnswers = new HashSet<StudentAnswer>();
        }

        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string? ChoiceText { get; set; }
        public bool? IsCorrect { get; set; }
        public bool IsDeleted { get; set; }

        public virtual QuizQuestion Question { get; set; } = null!;
        public virtual ICollection<StudentAnswer> StudentAnswers { get; set; }
    }
}
