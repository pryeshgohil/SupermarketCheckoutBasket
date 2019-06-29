using SupermarketCheckoutBasketService.Classes;
using SupermarketCheckoutBasketService.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketCheckoutBasketConsoleClient
{
    public class ConsoleSKUItem
    {
        public string Code { get; private set; }
        public int NumberOfItems { get; private set; }
        public bool RequestToExit { get; private set; }

        public ConsoleSKUItem RequestInput()
        {
            Console.WriteLine("Please enter the SKU Code you wish to add to the basket");
            string code = Console.ReadLine();

            if (code == "exit")
            {
                return new ConsoleSKUItem() { Code = "", NumberOfItems = 0, RequestToExit = true };
            }
   

            if (code.Length < 2 || code.Length > 4)
            {
                Console.WriteLine("Please enter a valid Sku Code");
                return null;
            }

            Console.WriteLine("Please enter the amount of items");
            string numberOfItemsString = Console.ReadLine();
            int numberOfItems;
            if (int.TryParse(numberOfItemsString, out numberOfItems))
            {
                return new ConsoleSKUItem() { Code = code, NumberOfItems = numberOfItems };
            }
            else
            {
                Console.WriteLine("Please enter a valid number of items");
            }

            return null;
        }
    }
    class Program
    {
        private static List<Sku> _listOfSku = new List<Sku>();
        static void Main(string[] args)
        {
            bool toExit = false;
            ConsoleSKUItem _consoleSKUItem = null;
            do
            {
                _consoleSKUItem = new ConsoleSKUItem().RequestInput();

                if (_consoleSKUItem != null)
                {
                    if (_consoleSKUItem.RequestToExit == true) toExit = true;
                    if (toExit == false)
                    {
                        AddToBasket(_consoleSKUItem.Code, _consoleSKUItem.NumberOfItems);
                        Console.WriteLine("Do you wish to add more items to the basket, type 'Y' or 'N'");

                        string answer = Console.ReadLine();

                        if (answer == "N") toExit = true;
                    }
                }
   

            } while (toExit == false) ;

            if (_listOfSku.Count() > 0)
            {
                Cashier cashier = new Cashier();
                double finalPrice = cashier.Checkout(_listOfSku);

                Console.WriteLine($"The final price is: {finalPrice.ToString("c")}");
                Console.WriteLine("Press enter to exit");
                Console.ReadLine();
            }

        }

        private static void AddToBasket(string code, int numberOfItems)
        {
            for (int i = 0; i < numberOfItems; i++)
            {
                AddToList(code);
            }
        }

        private static void AddToList(string code)
        {
            _listOfSku.Add(new Sku(code));
        }
    }
}
