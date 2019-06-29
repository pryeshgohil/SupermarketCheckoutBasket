using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketCheckoutBasketService.Classes
{
    public class Item
    {
        public Sku SKU { get; protected set; }

        public string Name { get; protected set; }

        public double Price { get; protected set; }

    }
}
