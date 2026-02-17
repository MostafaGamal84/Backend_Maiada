using System;
using System.Collections.Generic;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class TeacherHour:EntityBase
    {
        public int Id { get; set; }
        public double Minutes { get; set; }
        public double ArabSallary { get; set; }
        public double ForignSallary { get; set; }
        public DateTime CreationTime { get; set; }
        public int TeacherId { get; set; }
        public int SubscribeTypeId { get; set; }
        public bool IsDeleted { get; set; }
        public int? StudentId { get; set; }
        public int? AttendStatueId { get; set; }

        public virtual AttendStatue? AttendStatue { get; set; }
        public virtual SubscribeType SubscribeType { get; set; } = null!;
        public virtual Teacher Teacher { get; set; } = null!;
    }
}
