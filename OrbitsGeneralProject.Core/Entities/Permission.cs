using System;
using System.Collections.Generic;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class Permission:EntityBase
    {
        public Permission()
        {
            UserPermissions = new HashSet<UserPermission>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<UserPermission> UserPermissions { get; set; }
    }
}
