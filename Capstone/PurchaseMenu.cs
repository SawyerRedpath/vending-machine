using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class PurchaseMenu
    {
        private VendingMachine vm;
        // private Customer Customer = new Customer();

        private VendingMachineItem itemToConsume;

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
                    vm.FeedMoney(vm);
                    Console.Clear();
                }
                else if (input == "2")
                { 
                    Console.WriteLine(""); // Selecting Product
                    (string slotID, bool enoughMoney, bool notSoldOut) = vm.SelectProduct();
                    if (enoughMoney && slotID != "Q" && notSoldOut) 
                    {
                        itemToConsume = vm.CurrentStock[slotID].SlotItem;
                        vm.Dispense(vm, slotID);
                        Console.WriteLine($"{vm.CurrentStock[slotID].SlotItem.ProductName} dispensing now . . .");
                        System.Threading.Thread.Sleep(3000);
                    }
                    if (!notSoldOut)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Item is sold out!");
                        System.Threading.Thread.Sleep(2000);
                    }
                      
                    Console.Clear();
                }

                else if (input == "3")
                {
                    if (vm.Balance == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Transaction Cancelled");
                        Console.WriteLine();

                        System.Threading.Thread.Sleep(1000);

                        Console.WriteLine($"Returning to main menu now . . .");

                        System.Threading.Thread.Sleep(2000);
                        Console.Clear();

                    }
                    else
                    {
                        Console.WriteLine(""); // Finishing Transaction
                        vm.GiveChange(vm);
                        Console.WriteLine();

                        System.Threading.Thread.Sleep(1500);
                        Customer customer = new Customer();
                        if (itemToConsume != null)
                        {
                            customer.Consume(itemToConsume.Type);
                            Console.WriteLine();
                        }

                        System.Threading.Thread.Sleep(2000);

                        Console.WriteLine($"Returning to main menu now . . .");

                        System.Threading.Thread.Sleep(3500);
                        Console.Clear();
                    }
                }
                
                else if (input.ToUpper() == "Q")
                {
                    Console.WriteLine("Returning to main menu");
                    break;
                }
                else
                {
                    Console.WriteLine("Please try again");
                }
                

            }
        }
    }
}
