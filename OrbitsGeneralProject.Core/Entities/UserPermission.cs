using System;
using System.Collections.Generic;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class UserPermission:EntityBase
    {
        public int Id { get; set; }
        public int PermissionId { get; set; }
        public int UserId { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsDelete { get; set; }

        public virtual Permission Permission { get; set; } = null!;
        public virtual AspNetUser User { get; set; } = null!;
    }
}
