using System;
using System.Collections.Generic;

namespace ShopifyAPI.Models;

public partial class PaymentMethod
{
    public int PaymentMethodId { get; set; }

    public string? PaymentMethodName { get; set; }

    public string? Description { get; set; }

    public int? BranchId { get; set; }

    public virtual Branch? Branch { get; set; }
}
