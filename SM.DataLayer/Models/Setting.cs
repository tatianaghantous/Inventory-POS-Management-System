using System;
using System.Collections.Generic;

namespace SM.DataLayer.Models;

public partial class Setting
{
    public string SettingKey { get; set; } = null!;

    public string? SettingValue { get; set; }
}
