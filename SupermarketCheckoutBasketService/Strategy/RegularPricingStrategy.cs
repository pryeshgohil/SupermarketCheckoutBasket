using SupermarketCheckoutBasketService.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketCheckoutBasketService.Strategy
{
    public class RegularPricingStrategy : IPricingStrategy
    {
        private double _price;

        public Sku Sku { get; }

        public RegularPricingStrategy(string code, double price)
        {
            _price = price;
            Sku = new Sku(code);
        }

        public double GetPrice(int count)
        {
            return _price * count;
        }

    }
}
