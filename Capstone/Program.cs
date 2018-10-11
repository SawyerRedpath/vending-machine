using System;
using System.Collections.Generic;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            //Testing the stock vending machine method

            VendingMachine vm = new VendingMachine();
            vm.StockVendingMachine("vendingmachine.csv");

            MainMenu menu = new MainMenu(vm);

            menu.Display();

        }
    }
}
