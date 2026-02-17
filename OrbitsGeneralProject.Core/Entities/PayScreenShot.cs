using System;
using System.Collections.Generic;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class PayScreenShot:EntityBase
    {
        public int Id { get; set; }
        public string? PhotoUrl { get; set; }
        public int StudentId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Student Student { get; set; } = null!;
    }
}
