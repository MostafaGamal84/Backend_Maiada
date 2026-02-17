using System;
using System.Collections.Generic;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class CircleTime:EntityBase
    {
        public int Id { get; set; }
        public int? CircleId { get; set; }
        public int? TimeId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Circle? Circle { get; set; }
        public virtual Time? Time { get; set; }
    }
}
