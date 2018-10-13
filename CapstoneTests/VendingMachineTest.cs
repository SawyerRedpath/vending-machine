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

        [DataTestMethod]
        [DataRow("Test1", false)]
        [DataRow("12345", true)]
        [DataRow("Test", false)]
        public void IsDigitsOnly_ReturnFalseOrTrue_Appropriately(string testString, bool expected)
        {
            // Arrange
            VendingMachine vm = new VendingMachine();

            // Act
            bool digitOnly = vm.IsDigitsOnly(testString);

            // Assert
            Assert.AreEqual(expected, digitOnly);
        }

        [TestMethod]
        public void GiveChange_LeavesBalanceAt0 ()
        {
            // Arrange
            VendingMachine vm = new VendingMachine();
            vm.Balance = 12M;

            // Act
            vm.GiveChange(vm);

            // Assert
            Assert.AreEqual(0M, vm.Balance);
        }

        [TestMethod]
        public void VerifyProductCodeExists_ReturnFalseIfDoesNot()
        {
            // Arrange
            VendingMachine vm = new VendingMachine();


            // Act
            vm.StockVendingMachine("vendingmachine.csv");
            bool exists = vm.verifyProductCodeExists("Z1");

            // Assert
            Assert.AreEqual(exists, false);

        }

        [TestMethod]
        public void VerifyProductCodeExists_ReturnTrueIfDoes()
        {
            // Arrange
            VendingMachine vm = new VendingMachine();


            // Act
            vm.StockVendingMachine("vendingmachine.csv");
            bool exists = vm.verifyProductCodeExists("A1");

            // Assert
            Assert.AreEqual(exists, true);

        }

        [TestMethod]
        public void VerifyProductNotSoldOut_ReturnTrueIfNotSoldOut()
        {
            // Arrange
            VendingMachine vm = new VendingMachine();
            vm.StockVendingMachine("vendingmachine.csv");


            // Act
            vm.CurrentStock["A1"].SlotStock = 5;
            bool notSoldOut = vm.verifyProductNotSoldOut("A1");

            // Assert
            Assert.AreEqual(true, notSoldOut);
        }

        [TestMethod]
        public void VerifyProductNotSoldOut_ReturnFalseIfSoldOut()
        {
            // Arrange
            VendingMachine vm = new VendingMachine();
            vm.StockVendingMachine("vendingmachine.csv");


            // Act
            vm.CurrentStock["A1"].SlotStock = 0;
            bool notSoldOut = vm.verifyProductNotSoldOut("A1");

            // Assert
            Assert.AreEqual(false, notSoldOut);
        }
    }
}
