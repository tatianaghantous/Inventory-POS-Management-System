using System;
using System.Collections.Generic;

namespace SM.DataLayer.Models;

public partial class DailySale
{
    public long Id { get; set; }

    public string? Date { get; set; }

    public double? StartingBalance { get; set; }

    public double? EndBalance { get; set; }

    public double? Profit { get; set; }

    public double? TotalSales { get; set; }

    public long? BranchId { get; set; }

    public virtual Branch? Branch { get; set; }
}
