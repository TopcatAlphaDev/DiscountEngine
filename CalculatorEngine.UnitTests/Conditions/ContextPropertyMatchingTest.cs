using CalculatorEngine.UnitTests.Fixtures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorEngine.UnitTests.Conditions
{
    [TestClass]
    public class ContextPropertyMatchingTest
    {
        private Library.CalculatorEngine _calculatorEngine;

        [TestInitialize]
        public void Initialize()
        {
            _calculatorEngine = new Library.CalculatorEngine();
        }

        [TestMethod]
        public void MatchesContextProperties()
        {
            var item = ItemFactory.GetDefault((decimal)21.50);
            _calculatorEngine.AddItem(item);

            var discount = DiscountFactory.GetAmountDiscount(1);
            var condition = ConditionFactory.GetContextPropertiesCondition("Shop", "1");
            discount.AddCondition(condition);
            discount.Cumulating = true;
            _calculatorEngine.AddDiscount(discount);

            _calculatorEngine.AddProperty("Shop", "1");
            _calculatorEngine.Execute();

            Assert.AreEqual(item.FinalPrice, (decimal)20.50);
        }

        [TestMethod]
        public void NoDiscountAppliedBecauseDoesNotMatchContextProperties()
        {
            var item = ItemFactory.GetDefault((decimal)21.50);
            _calculatorEngine.AddItem(item);

            var discount = DiscountFactory.GetAmountDiscount(1);
            var condition = ConditionFactory.GetContextPropertiesCondition("Shop", "2");
            discount.AddCondition(condition);
            discount.Cumulating = true;
            _calculatorEngine.AddDiscount(discount);

            _calculatorEngine.AddProperty("Shop", "1");
            _calculatorEngine.Execute();

            Assert.AreEqual(item.FinalPrice, (decimal)21.50);
        }

        [TestMethod]
        public void DiscountAppliedWhenMatchingShop2()
        {
            var item = ItemFactory.GetDefault((decimal)21.50);
            _calculatorEngine.AddItem(item);

            var discount = DiscountFactory.GetAmountDiscount(1);
            var condition = ConditionFactory.GetContextPropertiesCondition("Shop", "1");
            discount.AddCondition(condition);
            discount.Cumulating = false;
            _calculatorEngine.AddDiscount(discount);

            var discount2 = DiscountFactory.GetAmountDiscount(2);
            var condition2 = ConditionFactory.GetContextPropertiesCondition("Shop", "2");
            discount2.AddCondition(condition2);
            discount2.Cumulating = false;
            _calculatorEngine.AddDiscount(discount2);

            _calculatorEngine.AddProperty("Shop", "2");
            _calculatorEngine.Execute();

            Assert.AreEqual(item.FinalPrice, (decimal)19.50);
        }

        [TestMethod]
        public void DiscountAppliedWhenMatchingCustomer10045123()
        {
            var item = ItemFactory.GetDefault((decimal)21.50);
            _calculatorEngine.AddItem(item);

            var discount = DiscountFactory.GetAmountDiscount(1);
            var condition = ConditionFactory.GetContextPropertiesCondition("Customer", "10045123");
            discount.AddCondition(condition);
            discount.Cumulating = false;
            _calculatorEngine.AddDiscount(discount);

            var discount2 = DiscountFactory.GetAmountDiscount(2);
            var condition2 = ConditionFactory.GetContextPropertiesCondition("Customer", "10045124");
            discount2.AddCondition(condition2);
            discount2.Cumulating = false;
            _calculatorEngine.AddDiscount(discount2);

            _calculatorEngine.AddProperty("Customer", "10045123");
            _calculatorEngine.Execute();

            Assert.AreEqual(item.FinalPrice, (decimal)20.50);
        }

        [TestMethod]
        public void DiscountAppliedWhenMatchingCustomerAndShop()
        {
            var item = ItemFactory.GetDefault((decimal)21.50);
            _calculatorEngine.AddItem(item);

            var discount = DiscountFactory.GetAmountDiscount(1);
            var condition = ConditionFactory.GetContextPropertiesCondition("Customer", "10045123");
            discount.AddCondition(condition);
            var condition2 = ConditionFactory.GetContextPropertiesCondition("Shop", "1");
            discount.AddCondition(condition2);
            discount.AddCondition(condition);
            discount.Cumulating = false;
            _calculatorEngine.AddDiscount(discount);

            _calculatorEngine.AddProperty("Customer", "10045123");
            _calculatorEngine.AddProperty("Shop", "1");
            _calculatorEngine.Execute();

            Assert.AreEqual(item.FinalPrice, (decimal)20.50);
        }

        [TestMethod]
        public void DiscountNotAppliedWhenMatchingCustomerButNotmatchingShop()
        {
            var item = ItemFactory.GetDefault((decimal)21.50);
            _calculatorEngine.AddItem(item);

            var discount = DiscountFactory.GetAmountDiscount(1);
            var condition = ConditionFactory.GetContextPropertiesCondition("Customer", "10045123");
            discount.AddCondition(condition);
            var condition2 = ConditionFactory.GetContextPropertiesCondition("Shop", "2");
            discount.AddCondition(condition2);
            discount.AddCondition(condition);
            discount.Cumulating = false;
            _calculatorEngine.AddDiscount(discount);

            _calculatorEngine.AddProperty("Customer", "10045123");
            _calculatorEngine.AddProperty("Shop", "1");
            _calculatorEngine.Execute();

            Assert.AreEqual(item.FinalPrice, (decimal)21.50);
        }

        [TestMethod]
        public void DiscountAppliedWhenNoMatchingContextPropertiesConfigured()
        {
            var item = ItemFactory.GetDefault((decimal)21.50);
            _calculatorEngine.AddItem(item);

            var discount = DiscountFactory.GetAmountDiscount(1);
            discount.Cumulating = true;
            _calculatorEngine.AddDiscount(discount);

            _calculatorEngine.AddProperty("Shop", "2");
            _calculatorEngine.Execute();

            Assert.AreEqual(item.FinalPrice, (decimal)20.50);
        }

        [TestMethod]
        public void BothDiscountsAppliedWhenMatchingContextProperties()
        {
            var item = ItemFactory.GetDefault((decimal)21.50);
            _calculatorEngine.AddItem(item);

            var discount = DiscountFactory.GetAmountDiscount(1);
            discount.Cumulating = true;
            _calculatorEngine.AddDiscount(discount);

            var discount2 = DiscountFactory.GetAmountDiscount(2);
            var condition2 = ConditionFactory.GetContextPropertiesCondition("Shop", "2");
            discount2.AddCondition(condition2);
            discount2.Cumulating = true;
            _calculatorEngine.AddDiscount(discount2);

            _calculatorEngine.AddProperty("Shop", "2");
            _calculatorEngine.Execute();

            Assert.AreEqual(item.FinalPrice, (decimal)18.50);
        }

        [TestMethod]
        public void OneDiscountsAppliedWhenNotMatchingContextProperties()
        {
            var item = ItemFactory.GetDefault((decimal)21.50);
            _calculatorEngine.AddItem(item);

            var discount = DiscountFactory.GetAmountDiscount(1);
            discount.Cumulating = true;
            _calculatorEngine.AddDiscount(discount);

            var discount2 = DiscountFactory.GetAmountDiscount(2);
            var condition2 = ConditionFactory.GetContextPropertiesCondition("Shop", "1");
            discount2.AddCondition(condition2);
            discount2.Cumulating = true;
            _calculatorEngine.AddDiscount(discount2);

            _calculatorEngine.AddProperty("Shop", "2");
            _calculatorEngine.Execute();

            Assert.AreEqual(item.FinalPrice, (decimal)20.50);
        }

        [TestCleanup]
        public void CleanUp()
        {
            _calculatorEngine.Clear();
        }
    }
}