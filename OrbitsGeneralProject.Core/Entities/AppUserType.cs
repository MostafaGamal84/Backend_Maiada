using System;
using System.Collections.Generic;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class AppUserType:EntityBase
    {
        public AppUserType()
        {
            AspNetUsers = new HashSet<AspNetUser>();
        }

        public int Id { get; set; }
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
    }
}
