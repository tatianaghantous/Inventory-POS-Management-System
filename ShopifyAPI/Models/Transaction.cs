using System;
using System.Collections.Generic;

namespace ShopifyAPI.Models;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public DateTime? TransactionDate { get; set; }

    public string? TransactionType { get; set; }

    public decimal? Amount { get; set; }

    public string? Description { get; set; }

    public int? OrderId { get; set; }

    public int? EmployeeId { get; set; }

    public int? PaymentMethodId { get; set; }

    public int? BranchId { get; set; }

    public virtual Branch? Branch { get; set; }

    public virtual OrderSummary? Order { get; set; }
}
