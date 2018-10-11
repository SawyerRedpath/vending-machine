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
        public Dictionary<string, VendingMachineItem> CurrentStock = new Dictionary<string, VendingMachineItem>();

        public void StockVendingMachine(string fileName)
        {
            //Read through fileName file


            using (StreamReader sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] itemInfo = line.Split('|');

                    string slot = itemInfo[0];
                    string itemName = itemInfo[1];
                    decimal itemPrice = decimal.Parse(itemInfo[2]);
                    string itemType = itemInfo[3];

                    VendingMachineItem item = new VendingMachineItem(itemName, itemPrice, itemType);
                    CurrentStock.Add(slot, item);
                }
            }

        }

       
    }

    
}
