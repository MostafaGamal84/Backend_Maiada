using System;
using System.Collections.Generic;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class Month:EntityBase
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
