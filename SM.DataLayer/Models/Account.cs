using System;
using System.Collections.Generic;

namespace SM.DataLayer.Models;

public partial class Account
{
    public long LoginId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? HashedPassword { get; set; }

    public long? HasPermission { get; set; }

    public string? LastConnection { get; set; }

    public long? BranchId { get; set; }

    public string? Email { get; set; }

    public long? BackupNumber { get; set; }

    public virtual ICollection<OrderSummary> OrderSummaries { get; set; } = new List<OrderSummary>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    
}
