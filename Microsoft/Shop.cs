using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft
{
    public class Shop
    {
        public string name { get; set; } = null!;

        public int quantity { get; set; }

        public int priceShop { get; set; }

        public int supplierId { get; set; }

        public int assortmentId { get; set; }

    }
}
