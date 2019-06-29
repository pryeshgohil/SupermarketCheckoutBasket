using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketCheckoutBasketService.Classes
{
    public class Sku
    {
        public string Value { get; }

        public Sku(string value)
        {
            Value = value;
        }

        private static bool IsValid(string value)
        {
            // validate
            return true;
        }

        public static implicit operator string(Sku sku)
        {
            return sku.Value;
        }

        public static explicit operator Sku(string value)
        {
            if (IsValid(value))
            {
                return new Sku(value);
            }
            throw new InvalidCastException();
        }
    }
}
