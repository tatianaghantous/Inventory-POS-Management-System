using System;
using System.Collections.Generic;

namespace SMDataLayer.Models;

public partial class Currency
{
    public long CurrencyId { get; set; }

    public string CurrencyCode { get; set; } = null!;

    public string CurrencyName { get; set; } = null!;

    public string? CurrencySymbol { get; set; }

    public string? Country { get; set; }

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}
