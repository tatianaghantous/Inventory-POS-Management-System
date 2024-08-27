using System;
using System.Collections.Generic;

namespace SMDataLayer.Models;

public partial class Purchase
{
    public long PurchaseId { get; set; }

    public long? SupplierId { get; set; }

    public long? ProductId { get; set; }

    public long? Quantity { get; set; }

    public long? BranchId { get; set; }

    public long? CurrencyId { get; set; }

    public string PurchaseOrderNumber { get; set; } = null!;

    public string PurchaseDate { get; set; } = null!;

    public string? ExpectedDeliveryDate { get; set; }

    public double TotalAmount { get; set; }

    public double? InitialPayment { get; set; }

    public double? TotalPaid { get; set; }

    public string? PaymentMethod { get; set; }

    public string? PaymentStatus { get; set; }

    public string PurchaseStatus { get; set; } = null!;

    public string? Notes { get; set; }

    public string? CreatedAt { get; set; }

    public string? UpdatedAt { get; set; }

    public virtual Branch? Branch { get; set; }

    public virtual Currency? Currency { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Supplier? Supplier { get; set; }
}
