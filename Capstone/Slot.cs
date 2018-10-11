using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Slot
    {
        public VendingMachineItem SlotItem {get; set; }

        public int SlotStock { get; set; } = 5;

        public string SlotIndex { get; set; }
    }
}
