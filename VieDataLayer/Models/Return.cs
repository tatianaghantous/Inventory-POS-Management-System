using System;
using System.Collections.Generic;

namespace SMDataLayer.Models;

public partial class Return
{
    public long ReturnId { get; set; }

    public string? ReturnDate { get; set; }

    public long? ReturnedProductId { get; set; }

    public long? NewProductId { get; set; }

    public long? QuantityReturned { get; set; }

    public string? ReturnReason { get; set; }

    public double? Refund { get; set; }

    public string? Description { get; set; }

    public double? PaidDifference { get; set; }

    public long? BranchId { get; set; }

    public long? CustomerId { get; set; }

    public virtual Branch? Branch { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Product? NewProduct { get; set; }
}
