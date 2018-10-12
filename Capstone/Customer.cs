using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Customer
    {

        public string Consume(string itemType)
        {
            string result = "";
            if(itemType == "Chip")
            {
                result = "Crunch, Crunch, Yum! ";
            }
            else if (itemType == "Candy")
            {
                result = "Munch, Munch, Yum! ";
            }
            else if (itemType == "Drink")
            {
                result = "Glug, Glug, Yum! ";
            }
            else if (itemType == "Gum")
            {
                result = "Chew, Chew, Yum! ";
            }
            return result;
        }
    }
}
