using System;
using System.Collections.Generic;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class Subscribe:EntityBase
    {
        public Subscribe()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public double TotalHours { get; set; }
        public double PriceLe { get; set; }
        public double PriceDollar { get; set; }
        public double PriceReyal { get; set; }
        public string? PhotoUrl { get; set; }
        public int SubscribeTypeId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual SubscribeType SubscribeType { get; set; } = null!;
        public virtual ICollection<Student> Students { get; set; }
    }
}
