using System;
using System.Collections.Generic;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class How:EntityBase
    {
        public int Id { get; set; }
        public int? NameAr { get; set; }
        public int? NameEn { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
