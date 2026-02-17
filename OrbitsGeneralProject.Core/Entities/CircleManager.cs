using System;
using System.Collections.Generic;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class CircleManager:EntityBase
    {
        public int Id { get; set; }
        public int? CircleId { get; set; }
        public int? ManagerId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Circle? Circle { get; set; }
        public virtual Manager? Manager { get; set; }
    }
}
