using System.Data;
using CalculatorEngine.Library;
using CalculatorEngine.UnitTests.Fixtures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorEngine.UnitTests.Discounts
{
    [TestClass]
    public class NoDiscountTest
    {
        private Library.CalculatorEngine _calculatorEngine;

        [TestInitialize]
        public void Initialize()
        {
            _calculatorEngine = new Library.CalculatorEngine();
        }

        [TestMethod]
        public void DataExceptionWhenNoItems()
        {
            Assert.ThrowsException<DataException>(() => _calculatorEngine.Execute());
        }

        [TestMethod]
        public void CalculatorAcceptsItem()
        {
            Assert.IsTrue(_calculatorEngine.AddItem(ItemFactory.GetDefault()));
        }

        [TestMethod]
        public void CalculatorAcceptsMultipleItems()
        {
            Assert.IsTrue(_calculatorEngine.AddItemsToCalculate(ItemFactory.GetListOfItems()));
        }

        [TestMethod]
        public void ExecuteSetsFinalPriceWithOriginalPrice()
        {
            var item = ItemFactory.GetDefault((decimal)21.50);
            _calculatorEngine.AddItem(item);

            _calculatorEngine.Execute();

            Assert.AreEqual(item.OriginalPrice, item.FinalPrice);
        }

        [TestMethod]
        public void ExecuteSetsFinalPriceWithOriginalPriceForBothItems()
        {
            var item = ItemFactory.GetDefault((decimal)21.50);
            _calculatorEngine.AddItem(item);

            var item2 = ItemFactory.GetDefault((decimal)15.50);
            _calculatorEngine.AddItem(item2);

            _calculatorEngine.Execute();

            Assert.AreEqual(item.OriginalPrice, item.FinalPrice);
            Assert.AreEqual(item2.OriginalPrice, item2.FinalPrice);
        }

        [TestMethod]
        public void ExecuteSetsFinalPriceWithOriginalPriceDoesNotImpactSecondItem()
        {
            var item = ItemFactory.GetDefault((decimal)21.50);
            _calculatorEngine.AddItem(item);

            var item2 = ItemFactory.GetDefault((decimal)15.50);
            _calculatorEngine.AddItem(item2);

            _calculatorEngine.Execute();

            Assert.AreNotEqual(item.OriginalPrice, item2.OriginalPrice);
            Assert.AreNotEqual(item.FinalPrice, item2.FinalPrice);
        }

        [TestCleanup]
        public void CleanUp()
        {
            _calculatorEngine.Clear();
        }
    }
}