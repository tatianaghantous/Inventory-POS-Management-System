using System;
using System.Collections.Generic;

namespace SMDataLayer.Models;

public partial class Transaction
{
    public long TransactionId { get; set; }

    public string? TransactionDate { get; set; }

    public string? TransactionType { get; set; }

    public double? Amount { get; set; }

    public string? Description { get; set; }

    public long? OrderId { get; set; }

    public long? EmployeeId { get; set; }

    public long? PaymentMethodId { get; set; }

    public long? BranchId { get; set; }

    public virtual Branch? Branch { get; set; }

    public virtual Account? Employee { get; set; }

    public virtual OrderSummary? Order { get; set; }
}
