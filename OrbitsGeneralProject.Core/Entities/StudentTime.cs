using System;
using System.Collections.Generic;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class StudentTime:EntityBase
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public int TimeId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Student? Student { get; set; }
        public virtual Time Time { get; set; } = null!;
    }
}
