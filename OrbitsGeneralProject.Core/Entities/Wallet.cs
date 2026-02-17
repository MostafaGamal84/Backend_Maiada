using System;
using System.Collections.Generic;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class Wallet:EntityBase
    {
        public Wallet()
        {
            WalletTransactions = new HashSet<WalletTransaction>();
        }

        public int Id { get; set; }
        public int StudentId { get; set; }
        public decimal Balance { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Student Student { get; set; } = null!;
        public virtual ICollection<WalletTransaction> WalletTransactions { get; set; }
    }
}
