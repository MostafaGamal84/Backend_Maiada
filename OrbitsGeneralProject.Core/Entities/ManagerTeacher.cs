using System;
using System.Collections.Generic;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class ManagerTeacher:EntityBase
    {
        public int Id { get; set; }
        public int? TeacherId { get; set; }
        public int? ManagerId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Manager? Manager { get; set; }
        public virtual Teacher? Teacher { get; set; }
    }
}
