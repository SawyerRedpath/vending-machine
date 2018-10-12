using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone
{
    public class AuditLog
    {
        private const string logFile = "Log.txt";
        
        //private string lineToPrint = "";

    

        public void PrintFeedMoneyLine (VendingMachine vm, decimal startingBalance, decimal finalBalance)
        {
            string actionDone = "FEED MONEY:";
            using (StreamWriter sw = new StreamWriter(logFile, true))
            {
                sw.WriteLine($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt")} {actionDone.PadRight(21)} ${startingBalance.ToString().PadRight(8)} ${vm.Balance}");
            }

        }

        public void PrintGiveChangeLine (VendingMachine vm, decimal startingBalance)
        {
            string actionDone = "GIVE CHANGE";
            using (StreamWriter sw = new StreamWriter(logFile, true))
            {
                sw.WriteLine($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt")} {actionDone.PadRight(21)} ${startingBalance.ToString().PadRight(8)} ${vm.Balance}");
            }
        }

        public void PrintDispenseItemLine(VendingMachine vm, decimal startingBalance, string slotID)
        {
            string actionDone = vm.CurrentStock[slotID].SlotItem.ProductName + " " + slotID;
            using (StreamWriter sw = new StreamWriter(logFile, true))
            {
                sw.WriteLine($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt")} {actionDone.PadRight(21)} ${startingBalance.ToString().PadRight(8)} ${vm.Balance}");
            }
        }
    }
}

