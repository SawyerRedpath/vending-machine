using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone
{
    public class VendingMachine
    {
        /// <summary>
        /// The name of the vending machine.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The balance of the vending machine.
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// The current stock of the vending machine.
        /// </summary>
        public Dictionary<string, Slot> CurrentStock = new Dictionary<string, Slot>();

        private AuditLog WriteLog = new AuditLog();

        public void StockVendingMachine(string fileName)
        {
            //Read through fileName file


            using (StreamReader sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] itemInfo = line.Split('|');

                    string position = itemInfo[0];
                    string itemName = itemInfo[1];
                    decimal itemPrice = decimal.Parse(itemInfo[2]);
                    string itemType = itemInfo[3];
                    Slot slot = new Slot();
                    slot.SlotIndex = position;
                    VendingMachineItem item = new VendingMachineItem(itemName, itemPrice, itemType);
                    slot.SlotItem = item;

                    CurrentStock.Add(position, slot);
                }
            }
        }

        public (string, bool, bool) SelectProduct()
        {
            string slotSelection = "";
            bool enoughMoney = true;
            bool notSoldOut = false;
            
            do
            {
                Console.WriteLine("Please enter your selections slot index. ");
                Console.WriteLine("Or enter Q to return to the previous menu");
                Console.WriteLine("Enter selection: ");
                slotSelection = Console.ReadLine().ToUpper();

                if (slotSelection == "Q")
                {
                    break;
                }

                verifyProductCodeExists(slotSelection);
                if (!verifyProductCodeExists(slotSelection))
                {
                    Console.WriteLine("Invalid selection!");
                }
                else
                {
                    notSoldOut = verifyProductNotSoldOut(slotSelection);
                }
                

                if (verifyProductCodeExists(slotSelection))
                {
                    if (  Balance < CurrentStock[slotSelection].SlotItem.Price )
                    {
                        Console.WriteLine();
                        Console.WriteLine($"{CurrentStock[slotSelection].SlotItem.ProductName}: ${CurrentStock[slotSelection].SlotItem.Price}. Please insert ${CurrentStock[slotSelection].SlotItem.Price - Balance}");
                        enoughMoney = false;
                        Console.WriteLine();
                    }
                }

            } while (!verifyProductCodeExists(slotSelection) ||  (Balance < CurrentStock[slotSelection].SlotItem.Price));
            //VendingMachineItem item = CurrentStock[slotSelection].SlotItem;
            //return  item;
            return (slotSelection, enoughMoney, notSoldOut);
        }

        public bool verifyProductNotSoldOut(string slotSelection)
        {
            if (CurrentStock.ContainsKey(slotSelection))
            {
                if (CurrentStock[slotSelection].SlotStock > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public bool verifyProductCodeExists(string slotSelection)
        {
            if (CurrentStock.ContainsKey(slotSelection))
            {
                return true;
            }
            return false;
        }

        public void PrintAllItemsInfo()
        {
            foreach (KeyValuePair<string, Slot> kvp in CurrentStock)
            {
                if (kvp.Value.SlotStock == 0)
                {
                    Console.WriteLine($"{kvp.Key} {kvp.Value.SlotItem.ProductName} {kvp.Value.SlotItem.Price} {kvp.Value.SlotItem.Type} SOLD OUT ");
                }
                else
                {
                    Console.WriteLine($"{kvp.Key} {kvp.Value.SlotItem.ProductName} {kvp.Value.SlotItem.Price} {kvp.Value.SlotItem.Type} {kvp.Value.SlotStock}");
                }
            }
        }

        public void GiveChange(VendingMachine vm)
        {
            decimal startingBalance = Balance;
            int quartersDue = 0;
            int dimesDue = 0;
            int nickelsDue = 0;
            while (Balance >= .25M)
            {
                quartersDue++;
                Balance -= .25M;
            }
            while (Balance >= .10M)
            {
                dimesDue++;
                Balance -= .10M;
            }
            while (Balance >= .05M)
            {
                nickelsDue++;
                Balance -= .05M;
            }
            Console.WriteLine($"Here is your change: {quartersDue} Quarters, {dimesDue} Dimes, {nickelsDue} Nickels");

            WriteLog.PrintGiveChangeLine(vm, startingBalance);
        }

        public void FeedMoney(VendingMachine vm)
        {
            string input = "";
            int moneyFed = 0;
            decimal startingBalance = 0.00M;
            while (input.ToUpper() != "Q")
            {
                Console.WriteLine("Please enter the amount of money to feed ");
                Console.WriteLine("1, 2, 5, 10 or enter Q when finished");
                Console.Write("Enter your selection: ");
                input = Console.ReadLine().ToUpper();
                if (input != "Q" && IsDigitsOnly(input) == true && (int.Parse(input) == 1 || int.Parse(input) == 2 || int.Parse(input) == 5 || int.Parse(input) == 10)  )
                {
                    startingBalance = Balance;
                    moneyFed += int.Parse(input); 
                    Balance += moneyFed;
                    WriteLog.PrintFeedMoneyLine(vm, startingBalance, Balance);
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid input, machine accepts 1, 2, 5, or 10");
                    Console.WriteLine();
                }
            }
        }

        public void Dispense(VendingMachine vm, string slotID)
        {
            decimal startingBalance = Balance;
            // We will decrement the item stock by 1
            CurrentStock[slotID].SlotStock--;
            // We will decrement the balance by item price
            Balance -= CurrentStock[slotID].SlotItem.Price;
            WriteLog.PrintDispenseItemLine(vm, startingBalance, slotID);
        }

        public bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
    }

    
}
