using System;
using System.Collections.Generic;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class Manager:EntityBase
    {
        public Manager()
        {
            CircleManagers = new HashSet<CircleManager>();
            ManagerStudents = new HashSet<ManagerStudent>();
            ManagerTeachers = new HashSet<ManagerTeacher>();
            ManagerTimes = new HashSet<ManagerTime>();
        }

        public int Id { get; set; }
        public int? GovernorateId { get; set; }

        public virtual Governorate? Governorate { get; set; }
        public virtual AspNetUser IdNavigation { get; set; } = null!;
        public virtual ICollection<CircleManager> CircleManagers { get; set; }
        public virtual ICollection<ManagerStudent> ManagerStudents { get; set; }
        public virtual ICollection<ManagerTeacher> ManagerTeachers { get; set; }
        public virtual ICollection<ManagerTime> ManagerTimes { get; set; }
    }
}
