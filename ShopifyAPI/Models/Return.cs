using System;
using System.Collections.Generic;

namespace ShopifyAPI.Models;

public partial class Return
{
    public int ReturnId { get; set; }

    public DateTime? ReturnDate { get; set; }

    public int? ReturnedProductId { get; set; }

    public int? NewProductId { get; set; }

    public int? QuantityReturned { get; set; }

    public string? ReturnReason { get; set; }

    public decimal? Refund { get; set; }

    public string? Description { get; set; }

    public decimal? PaidDifference { get; set; }

    public int? BranchId { get; set; }

    public virtual Branch? Branch { get; set; }

    public virtual Product? NewProduct { get; set; }
}
