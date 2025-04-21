using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft
{
    public class Shop
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int Quantity { get; set; }

        public int PriceShop { get; set; }

        public int SupplierId { get; set; }

        public int AssortmentId { get; set; }

    }
}
