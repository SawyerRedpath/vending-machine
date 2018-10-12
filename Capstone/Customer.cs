using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Customer
    {

        public void Consume(string itemType)
        {
            if(itemType == "Chip")
            {
                Console.WriteLine("Crunch, Crunch, Yum! ");
            }
            else if (itemType == "Candy")
            {
                Console.WriteLine("Munch, Munch, Yum! ");
            }
            else if (itemType == "Drink")
            {
                Console.WriteLine("Glug, Glug, Yum! ");
            }
            else if (itemType == "Gum")
            {
                Console.WriteLine("Chew, Chew, Yum! ");
            }
        }
    }
}
