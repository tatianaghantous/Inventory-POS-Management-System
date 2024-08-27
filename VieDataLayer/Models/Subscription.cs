using System;
using System.Collections.Generic;

namespace SMDataLayer.Models;

public partial class Subscription
{
    public long Id { get; set; }

    public double Amount { get; set; }

    public string PaidDate { get; set; } = null!;

    public string PaymentMethod { get; set; } = null!;
}
