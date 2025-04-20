using System;
using System.Collections.Generic;

namespace SM.DataLayer.Models;

public partial class Service
{
    public long ServiceId { get; set; }

    public double ServiceCost { get; set; }

    public double ServiceSellingPrice { get; set; }

    public string? ServiceType { get; set; }

    public string? ServiceDate { get; set; }

    public double? ServiceProfit { get; set; }

    public long IsPaid { get; set; }

    public string? ServiceDuration { get; set; }

    public long? BranchId { get; set; }

    public string? Description { get; set; }

    public long? CustomerId { get; set; }

    public virtual Branch? Branch { get; set; }

    public virtual Customer? Customer { get; set; }
}
