using System;
using System.Collections.Generic;

namespace Malchikov.Models;

public partial class Assortment
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Type { get; set; }

    public string? Volume { get; set; }

    public string? PriceShop { get; set; }

    public virtual ICollection<Shop> Shops { get; set; } = new List<Shop>();
}
