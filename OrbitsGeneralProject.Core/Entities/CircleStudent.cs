using System;
using System.Collections.Generic;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class CircleStudent:EntityBase
    {
        public int Id { get; set; }
        public int CircleId { get; set; }
        public int? StudentId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Circle Circle { get; set; } = null!;
        public virtual Student? Student { get; set; }
    }
}
