using System.Data;
using CalculatorEngine.Library;
using CalculatorEngine.UnitTests.Fixtures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorEngine.UnitTests.Discounts
{
    [TestClass]
    public class PercentageDiscountTest
    {
        private Library.CalculatorEngine _calculatorEngine;

        [TestInitialize]
        public void Initialize()
        {
            _calculatorEngine = new Library.CalculatorEngine();
        }

        [TestMethod]
        public void FinalPriceWith10Percent()
        {
            var item = ItemFactory.GetDefault((decimal)21.50);
            item.AddProperty("Group", "Shoe");
            _calculatorEngine.AddItem(item);

            var discount = DiscountFactory.GetPercentageDiscount(10);
            discount.AddCondition(ConditionFactory.GetItemPropertiesCondition());
            _calculatorEngine.AddDiscount(discount);

            _calculatorEngine.Execute();

            Assert.AreEqual(item.FinalPrice, (decimal)19.35);
        }

        [TestMethod]
        public void PercentageAfterAmountDiscount()
        {
            var item = ItemFactory.GetDefault((decimal)21.50);
            item.AddProperty("Group", "Shoe");
            _calculatorEngine.AddItem(item);

            var discount = DiscountFactory.GetAmountDiscount(5,0);
            discount.AddCondition(ConditionFactory.GetItemPropertiesCondition());
            _calculatorEngine.AddDiscount(discount);

            var discount2 = DiscountFactory.GetPercentageDiscount(10,1);
            discount2.AddCondition(ConditionFactory.GetItemPropertiesCondition());
            discount2.Cumulating = true;
            _calculatorEngine.AddDiscount(discount2);

            _calculatorEngine.Execute();

            Assert.AreEqual(item.FinalPrice, (decimal)14.85);
        }

        [TestMethod]
        public void NotCumulatingAmountWinsAbovePercentage()
        {
            var item = ItemFactory.GetDefault((decimal)21.50);
            item.AddProperty("Group", "Shoe");
            _calculatorEngine.AddItem(item);

            var discount = DiscountFactory.GetAmountDiscount(5, 0);
            discount.AddCondition(ConditionFactory.GetItemPropertiesCondition());
            _calculatorEngine.AddDiscount(discount);

            var discount2 = DiscountFactory.GetPercentageDiscount(10, 1);
            discount2.AddCondition(ConditionFactory.GetItemPropertiesCondition());
            discount2.Cumulating = false;
            _calculatorEngine.AddDiscount(discount2);

            _calculatorEngine.Execute();

            Assert.AreEqual(item.FinalPrice, (decimal)16.50);
        }

        [TestCleanup]
        public void CleanUp()
        {
            _calculatorEngine.Clear();
        }
    }
}