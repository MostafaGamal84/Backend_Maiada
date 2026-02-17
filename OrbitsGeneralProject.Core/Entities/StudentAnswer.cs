using System;
using System.Collections.Generic;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class StudentAnswer:EntityBase
    {
        public int Id { get; set; }
        public int AttemptId { get; set; }
        public int QuestionId { get; set; }
        public int? SelectedChoiceId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual StudentQuizAttempt Attempt { get; set; } = null!;
        public virtual QuizQuestion Question { get; set; } = null!;
        public virtual QuestionChoice? SelectedChoice { get; set; }
    }
}
