using System;
using System.Collections.Generic;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class ManagerStudent:EntityBase
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public int? ManagerId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Manager? Manager { get; set; }
        public virtual Student? Student { get; set; }
    }
}
