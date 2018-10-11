using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class PurchaseMenu
    {
        private VendingMachine vm;
        public PurchaseMenu(VendingMachine vm)
        {
            this.vm = vm;
        }
        public void Display()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Purchase Menu");
                Console.WriteLine("1] >> Feed Money ");
                Console.WriteLine("2] >> Select Product");
                Console.WriteLine("3] >> Finish Transaction");
                Console.WriteLine("Q] >> Return to Main Menu");

                Console.Write("Please make a selection: ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    Console.WriteLine(""); // Feeding Money
                    vm.FeedMoney();
                }
                else if (input == "2")
                {
                    Console.WriteLine(""); // Selecting Product
                    string item = vm.SelectProduct();
                    vm.Dispense(item);
                }
                else if (input == "3")
                {
                    Console.WriteLine(""); // Finishing Transaction
                }
                else if (input == "Q")
                {
                    Console.WriteLine("Returning to main menu");
                    break;
                }
                else
                {
                    Console.WriteLine("Please try again");
                }
                
                Console.ReadLine();
            }
        }
    }
}
