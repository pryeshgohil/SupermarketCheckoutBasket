using SupermarketCheckoutBasketService.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketCheckoutBasketService.Strategy
{
    public class SpecialOfferStrategy : IPricingStrategy
    {
        private double _pricePerOne;
        private double _pricePerX;
        private int _x;

        public Sku Sku { get; }

        public SpecialOfferStrategy(string code, double price, double pricePerX, int x)
        {
            _pricePerOne = price;
            _pricePerX = pricePerX;
            _x = x;
            Sku = new Sku(code);
        }

        public double GetPrice(int count)
        {
            if (count == 0)
            {
                return 0;
            }

            double result = 0;

            while (count >= _x)
            {
                result = result + _pricePerX;
                count = count - _x;
            }

            return result + (_pricePerOne * count);
        }
    }
}
