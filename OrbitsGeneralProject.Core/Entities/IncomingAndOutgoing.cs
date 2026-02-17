using System;
using System.Collections.Generic;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class IncomingAndOutgoing:EntityBase
    {
        public int Id { get; set; }
        public double Incoming { get; set; }
        public double Outgoing { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
