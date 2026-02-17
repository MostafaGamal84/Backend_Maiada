using System;
using System.Collections.Generic;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class WalletTransaction:EntityBase
    {
        public int Id { get; set; }
        public int WalletId { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; } = null!;
        public int? ReferenceId { get; set; }
        public string? Notes { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Wallet Wallet { get; set; } = null!;
    }
}
