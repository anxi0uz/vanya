using System;
using System.Collections.Generic;

namespace Malchikov.Models;

public partial class Supplier
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Type { get; set; } = null!;

    public int Quatity { get; set; }

    public int PriceSupplier { get; set; }

    public string Address { get; set; } = null!;

    public virtual ICollection<Shop> Shops { get; set; } = new List<Shop>();
}
