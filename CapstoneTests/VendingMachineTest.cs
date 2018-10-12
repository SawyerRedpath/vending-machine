using Capstone;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineTest
    {
        //VendingMachineItem test1 = new VendingMachineItem("test1", 0, "Gum");
        [DataTestMethod]
        [DataRow("Chip", "Crunch, Crunch, Yum! ")]
        [DataRow("Gum", "Chew, Chew, Yum! ")]
        [DataRow("Candy", "Munch, Munch, Yum! ")]
        [DataRow("Drink", "Glug, Glug, Yum! ")]
        public void ConsumeItem_PrintsCorrectString(string itemType, string expectedString)
        {
            Customer customer = new Customer();

            string consume = customer.Consume(itemType);

            Assert.AreEqual(expectedString, consume);
        }
    }
}
