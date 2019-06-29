using SupermarketCheckoutBasketService.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketCheckoutBasketService.Factory
{
    public class Cashier
    {
        private List<IPricingStrategy> _pricingStrategies;

        public Cashier()
        {
            PricingStrategyFactory pricingStrategyFactory = new PricingStrategyFactory();
            _pricingStrategies =  pricingStrategyFactory.GetPricingStrategiesFromTempStore();
        }

        public Cashier(List<IPricingStrategy> pricingStrategies)
        {
            _pricingStrategies = pricingStrategies;
        }

        public double Checkout(IList<Sku> products)
        {
            double result = 0;
            foreach (var strategy in _pricingStrategies)
            {
                var prods = products.Where(p => p.Value == strategy.Sku.Value);
                result = result + strategy.GetPrice(prods.Count());
            }

            return Math.Round(result, 2);
        }
    }
}
