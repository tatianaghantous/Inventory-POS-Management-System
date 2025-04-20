using System;
using System.Collections.Generic;

namespace SM.DataLayer.Models;

public partial class Variant
{
    public long VariantId { get; set; }

    public long? ProductId { get; set; }

    public long? OptionId { get; set; }

    public string Value { get; set; } = null!;

    public double? InitialPrice { get; set; }

    public double? SellingPrice { get; set; }

    public string? Barcode { get; set; }

    public string? Sku { get; set; }

    public long? GrpByVariantId { get; set; }

    public virtual Variant? GrpByVariant { get; set; }

    public virtual ICollection<Variant> InverseGrpByVariant { get; set; } = new List<Variant>();

    public virtual Option? Option { get; set; }

    public virtual Product? Product { get; set; }
}
