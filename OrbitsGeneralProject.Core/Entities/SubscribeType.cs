using System;
using System.Collections.Generic;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class SubscribeType:EntityBase
    {
        public SubscribeType()
        {
            HoursRecords = new HashSet<HoursRecord>();
            Subscribes = new HashSet<Subscribe>();
            TeacherHours = new HashSet<TeacherHour>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public double ArabPrice { get; set; }
        public double ForignPrice { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<HoursRecord> HoursRecords { get; set; }
        public virtual ICollection<Subscribe> Subscribes { get; set; }
        public virtual ICollection<TeacherHour> TeacherHours { get; set; }
    }
}
