using System;
using System.Collections.Generic;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class Admin:EntityBase
    {
        public int Id { get; set; }

        public virtual AspNetUser IdNavigation { get; set; } = null!;
    }
}
