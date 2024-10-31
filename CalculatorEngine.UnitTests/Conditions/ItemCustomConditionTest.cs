using System.Linq.Dynamic.Core.Exceptions;
using CalculatorEngine.UnitTests.Fixtures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorEngine.UnitTests.Conditions
{
    [TestClass]
    public class ItemCustomConditionTest
    {
        private Library.CalculatorEngine _calculatorEngine;

        [TestInitialize]
        public void Initialize()
        {
            _calculatorEngine = new Library.CalculatorEngine();
        }

        [TestMethod]
        public void DiscountWhenPriceIsGreaterThen10()
        {
            var item = ItemFactory.GetDefault((decimal)21.50);
            item.AddProperty("Group", "Shoe");
            _calculatorEngine.AddItem(item);

            var discount = DiscountFactory.GetAmountDiscount(5);
            var condition = ConditionFactory.GetItemCustomCondition("OriginalPrice > 10");
            discount.AddCondition(condition);
            _calculatorEngine.AddDiscount(discount);

            _calculatorEngine.Execute();

            Assert.AreEqual(item.FinalPrice, (decimal)16.50);
        }

        [TestMethod]
        public void NoDiscountWhenPriceIsBelow30()
        {
            var item = ItemFactory.GetDefault((decimal)21.50);
            item.AddProperty("Group", "Shoe");
            _calculatorEngine.AddItem(item);

            var discount = DiscountFactory.GetAmountDiscount(5);
            var condition = ConditionFactory.GetItemCustomCondition("OriginalPrice > 30");
            discount.AddCondition(condition);
            _calculatorEngine.AddDiscount(discount);

            _calculatorEngine.Execute();

            Assert.AreEqual(item.FinalPrice, (decimal)21.50);
        }

        [TestMethod]
        public void InvalidQueryThrowsException()
        {
            Assert.ThrowsException<ParseException>(() => ConditionFactory.GetItemCustomCondition("Nonsense > 30"));
        }

        [TestCleanup]
        public void CleanUp()
        {
            _calculatorEngine.Clear();
        }
    }
}