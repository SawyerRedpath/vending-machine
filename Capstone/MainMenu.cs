using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class MainMenu
    {
        private VendingMachine vm;
        public MainMenu(VendingMachine vm)
        {
            this.vm = vm;
        }
        public void Display()
        {
            while (true)
            {
                PrintHeader();

                Console.WriteLine();
                Console.WriteLine("Main Menu");
                Console.WriteLine("1] >> Display Vending Machine Items");
                Console.WriteLine("2] >> Make Purchase");
                Console.WriteLine("Q] >> Quit");

                Console.Write("Please make a selection: ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    Console.WriteLine("Displaying Vend-O-Matic 500 Items...");
                    vm.PrintAllItemsInfo();
                }
                else if (input == "2")
                {
                    Submenu1CLI submenu = new Submenu1CLI();
                    submenu.Display();
                }
                else if (input == "Q")
                {
                    Console.WriteLine("Quitting");
                    break;
                }
                else
                {
                    Console.WriteLine("Please try again");
                }

                Console.ReadLine();
                Console.Clear();
            }
        }
        private void PrintHeader()
        {
            Console.WriteLine("Vend-O-Matic 500 /nWelcome!");
        }

        private void DisplayItemInfo()
        {
            foreach (KeyValuePair<string, VendingMachineItem> kvp in vm.CurrentStock)
            {
                VendingMachineItem item = kvp.Value;
                Console.WriteLine(kvp.Key + " " + item.ProductName + " " + item.Price + " " + item.Type);
            }
        }

    }
}
