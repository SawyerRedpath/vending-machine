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

        public void GiveChange()
        {
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


        }

        public void PrintAllItemsInfo()
        {
            foreach (KeyValuePair<string, VendingMachineItem> kvp in CurrentStock)
            {
                if (kvp.Key
                VendingMachineItem item = kvp.Value;
                Console.WriteLine(kvp.Key + " " + item.ProductName + " " + item.Price + " " + item.Type);
            }
        }

       
    }

    
}
