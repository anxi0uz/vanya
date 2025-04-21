using System;
using System.Collections.Generic;

namespace Malchikov.Models;

public partial class Shop
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Quantity { get; set; }

    public int PriceShop { get; set; }

    public int SupplierId { get; set; }

    public int AssortmentId { get; set; }

    public virtual Assortment Assortment { get; set; } = null!;

    public virtual Supplier Supplier { get; set; } = null!;
}
