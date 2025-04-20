using System;
using System.Collections.Generic;

namespace SM.DataLayer.Models;

public partial class PaymentMethod
{
    public long PaymentMethodId { get; set; }

    public string? PaymentMethodName { get; set; }

    public string? Description { get; set; }

    public long? BranchId { get; set; }

    public virtual Branch? Branch { get; set; }
}
