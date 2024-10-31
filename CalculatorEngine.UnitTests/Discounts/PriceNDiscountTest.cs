using System.Data;
using CalculatorEngine.Library;
using CalculatorEngine.UnitTests.Fixtures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorEngine.UnitTests.Discounts
{
    [TestClass]
    public class PriceNDiscountTest
    {
        private Library.CalculatorEngine _calculatorEngine;

        [TestInitialize]
        public void Initialize()
        {
            _calculatorEngine = new Library.CalculatorEngine();
        }

        [TestMethod]
        public void FinalPriceIsPrice2()
        {
            var item = ItemFactory.GetDefault((decimal)21.50);
            item.AddProperty("Group", "Shoe");
            item.Price2 = (decimal)19.50;
            _calculatorEngine.AddItem(item);

            var discount = DiscountFactory.GetPrice2Discount(true);
            discount.AddCondition(ConditionFactory.GetItemPropertiesCondition());
            _calculatorEngine.AddDiscount(discount);

            _calculatorEngine.Execute();

            Assert.AreEqual(item.FinalPrice, (decimal)19.50);
        }

        [TestMethod]
        public void FinalPriceIsPrice2WhenActiveDateTimeIsValid()
        {
            var item = ItemFactory.GetDefault((decimal)21.50);
            item.Price2 = (decimal)19.50;
            item.Price3 = (decimal)16.50;
            _calculatorEngine.AddItem(item);

            var discount = DiscountFactory.GetPrice2Discount(true);
            discount.AddCondition(ConditionFactory.GetValidActivePeriodCondition());
            _calculatorEngine.AddDiscount(discount);

            var discount2 = DiscountFactory.GetPrice3Discount(true);
            discount2.AddCondition(ConditionFactory.GetInValidActivePeriodCondition());
            _calculatorEngine.AddDiscount(discount2);

            _calculatorEngine.Execute();

            Assert.AreEqual(item.FinalPrice, (decimal)19.50);
        }

        [TestMethod]
        public void FinalPriceIsNotPrice3WhenActiveDateTimeIsValid()
        {
            var item = ItemFactory.GetDefault((decimal)21.50);
            item.Price2 = (decimal)19.50;
            item.Price3 = (decimal)16.50;
            _calculatorEngine.AddItem(item);

            var discount = DiscountFactory.GetPrice2Discount(true);
            discount.AddCondition(ConditionFactory.GetInValidActivePeriodCondition());
            _calculatorEngine.AddDiscount(discount);

            var discount2 = DiscountFactory.GetPrice3Discount(true);
            discount2.AddCondition(ConditionFactory.GetValidActivePeriodCondition());
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