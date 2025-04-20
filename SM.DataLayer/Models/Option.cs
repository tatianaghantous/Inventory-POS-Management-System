using System;
using System.Collections.Generic;

namespace SM.DataLayer.Models;

public partial class Option
{
    public long OptionId { get; set; }

    public string OptionName { get; set; } = null!;

    public virtual ICollection<Variant> Variants { get; set; } = new List<Variant>();
}
