using SupermarketCheckoutBasketService.Classes;
using SupermarketCheckoutBasketService.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketCheckoutBasketService.Factory
{
    public class PricingStrategyFactory
    {


        //temp store
        public List<IPricingStrategy> GetPricingStrategiesFromTempStore()
        {
            var listOfPricingStrategies = new List<IPricingStrategy>()
           {
               { new SpecialOfferStrategy("A99", 0.50, 1.30, 3 ) },
               { new SpecialOfferStrategy("B15", 0.30, 0.45, 2 ) },
               { new RegularPricingStrategy("C40", 1.80) },
               { new RegularPricingStrategy("T23", 0.99 ) }
           };

            return listOfPricingStrategies;
        }


        //live store
        public List<IPricingStrategy> GetPricingStrategiesFromLiveStore()
        {
            return new List<IPricingStrategy>();
        }
    }
}
