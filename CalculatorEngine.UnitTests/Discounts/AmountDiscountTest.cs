using System.Data;
using CalculatorEngine.Library;
using CalculatorEngine.UnitTests.Fixtures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorEngine.UnitTests.Discounts
{
    [TestClass]
    public class AmountDiscountTest
    {
        private Library.CalculatorEngine _calculatorEngine;

        [TestInitialize]
        public void Initialize()
        {
            _calculatorEngine = new Library.CalculatorEngine();
        }

        [TestMethod]
        public void FinalPriceIsOriginalMinus5Euro()
        {
            var item = ItemFactory.GetDefault((decimal)21.50);
            item.AddProperty("Group", "Shoe");
            _calculatorEngine.AddItem(item);

            var discount = DiscountFactory.GetAmountDiscount(5);
            discount.AddCondition(ConditionFactory.GetItemPropertiesCondition());
            _calculatorEngine.AddDiscount(discount);

            _calculatorEngine.Execute();

            Assert.AreEqual(item.FinalPrice, (decimal)16.50);
        }

        [TestMethod]
        public void CumulativeAmountDiscount()
        {
            var item = ItemFactory.GetDefault((decimal)21.50);
            item.AddProperty("Group", "Shoe");
            _calculatorEngine.AddItem(item);

            var discount = DiscountFactory.GetAmountDiscount(5, 0);
            discount.AddCondition(ConditionFactory.GetItemPropertiesCondition());
            discount.Cumulating = true;
            _calculatorEngine.AddDiscount(discount);

            var discount2 = DiscountFactory.GetAmountDiscount(1, 1);
            discount2.AddCondition(ConditionFactory.GetItemPropertiesCondition());
            discount2.Cumulating = true;
            _calculatorEngine.AddDiscount(discount2);

            _calculatorEngine.Execute();

            Assert.AreEqual(item.FinalPrice, (decimal)15.50);
        }

        [TestMethod]
        public void BestDiscountWinsForAmountDiscount()
        {
            var item = ItemFactory.GetDefault((decimal)21.50);
            item.AddProperty("Group", "Shoe");
            _calculatorEngine.AddItem(item);

            var discount = DiscountFactory.GetAmountDiscount(5,0);
            discount.AddCondition(ConditionFactory.GetItemPropertiesCondition());
            discount.Cumulating = false;
            _calculatorEngine.AddDiscount(discount);

            var discount2 = DiscountFactory.GetAmountDiscount((decimal)5.5, 1);
            discount2.AddCondition(ConditionFactory.GetItemPropertiesCondition());
            discount2.Cumulating = false;
            _calculatorEngine.AddDiscount(discount2);

            var discount3 = DiscountFactory.GetAmountDiscount(1, 2);
            discount3.AddCondition(ConditionFactory.GetItemPropertiesCondition());
            discount3.Cumulating = false;
            _calculatorEngine.AddDiscount(discount3);

            _calculatorEngine.Execute();

            Assert.AreEqual(item.FinalPrice, (decimal)16.00);
        }

        [TestMethod]
        public void ItemsWithMultipleAmountDiscount()
        {
            var item = ItemFactory.GetDefault((decimal)21.50);
            item.AddProperty("Group", "Shoe");
            item.AddProperty("Group", "Clothes");
            _calculatorEngine.AddItem(item);

            var discount = DiscountFactory.GetAmountDiscount(1,0);
            discount.AddCondition(ConditionFactory.GetItemPropertiesCondition());
            discount.Cumulating = true;
            _calculatorEngine.AddDiscount(discount);

            var discount2 = DiscountFactory.GetAmountDiscount(5, 1);
            discount2.AddCondition(ConditionFactory.GetItemPropertiesCondition("Group", "Clothes"));
            discount2.Cumulating = true;
            _calculatorEngine.AddDiscount(discount2);

            _calculatorEngine.Execute();

            Assert.AreEqual(item.FinalPrice, (decimal)15.50);
        }

        [TestCleanup]
        public void CleanUp()
        {
            _calculatorEngine.Clear();
        }
    }
}