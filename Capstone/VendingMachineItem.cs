using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class VendingMachineItem
    {
        /// <summary>
        /// The name of the product.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// The price of the item.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// The type of the item.
        /// </summary>
        public string Type { get; set;  }

        /// <summary>
        /// Constructs a new instance of Vending Machine Item.
        /// </summary>
        /// <param name="productName"></param>
        /// <param name="price"></param>
        /// <param name="type"></param>
        public VendingMachineItem(string productName, decimal price, string type)
        {
            this.ProductName = productName;
            this.Price = price;
            this.Type = type;
        }
    }
}
