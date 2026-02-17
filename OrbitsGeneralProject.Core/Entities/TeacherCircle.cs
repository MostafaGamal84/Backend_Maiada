using System;
using System.Collections.Generic;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class TeacherCircle:EntityBase
    {
        public int Id { get; set; }
        public int? TeacherId { get; set; }
        public int? CircleId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Circle? Circle { get; set; }
        public virtual Teacher? Teacher { get; set; }
    }
}
