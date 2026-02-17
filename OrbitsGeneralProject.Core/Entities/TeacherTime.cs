using System;
using System.Collections.Generic;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class TeacherTime:EntityBase
    {
        public int Id { get; set; }
        public int? TeacherId { get; set; }
        public int? TimeId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Teacher? Teacher { get; set; }
        public virtual Time? Time { get; set; }
    }
}
