using System;
using System.Collections.Generic;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class HoursRecord:EntityBase
    {
        public int Id { get; set; }
        public double PriceLe { get; set; }
        public double PriceDollar { get; set; }
        public double PriceReyal { get; set; }
        public int SubscribeTypeId { get; set; }
        public int? TeacherId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual SubscribeType SubscribeType { get; set; } = null!;
        public virtual Teacher? Teacher { get; set; }
    }
}
