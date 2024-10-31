using CalculatorEngine.UnitTests.Fixtures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorEngine.UnitTests.Conditions
{
    [TestClass]
    public class TotalPriceTest
    {
        private Library.CalculatorEngine _calculatorEngine;

        [TestInitialize]
        public void Initialize()
        {
            _calculatorEngine = new Library.CalculatorEngine();
        }

        [TestMethod]
        public void NoDiscountWhenTotalPriceBelow40()
        {
            var item = ItemFactory.GetDefault((decimal)21.50);
            item.AddProperty("Group", "Shoe");
            _calculatorEngine.AddItem(item);

            var discount = DiscountFactory.GetPercentageDiscount(10);
            var condition = ConditionFactory.GetTotalPriceCondition(40);
            discount.AddCondition(condition);
            _calculatorEngine.AddDiscount(discount);

            _calculatorEngine.Execute();

            Assert.AreEqual(item.FinalPrice, (decimal)21.50);
        }

        [TestMethod]
        public void PercentageDiscountWhenTotalPriceAbove40()
        {
            var item = ItemFactory.GetDefault((decimal)21.50);
            item.AddProperty("Group", "Shoe");
            _calculatorEngine.AddItem(item);

            var item2 = ItemFactory.GetDefault((decimal)25.50);
            item2.AddProperty("Group", "Shoe");
            _calculatorEngine.AddItem(item2);

            var discount = DiscountFactory.GetPercentageDiscount(10);
            var condition = ConditionFactory.GetTotalPriceCondition(40);
            discount.AddCondition(condition);
            _calculatorEngine.AddDiscount(discount);

            _calculatorEngine.Execute();

            Assert.AreEqual(item.FinalPrice, (decimal)19, 35);
            Assert.AreEqual(item2.FinalPrice, (decimal)22, 95);
        }

        [TestCleanup]
        public void CleanUp()
        {
            _calculatorEngine.Clear();
        }
    }
}