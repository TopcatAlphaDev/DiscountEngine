using System.Data;
using CalculatorEngine.Library;
using CalculatorEngine.UnitTests.Fixtures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorEngine.UnitTests.Conditions
{
    [TestClass]
    public class ItemPropertyMatchingTest
    {
        private Library.CalculatorEngine _calculatorEngine;

        [TestInitialize]
        public void Initialize()
        {
            _calculatorEngine = new Library.CalculatorEngine();
        }

        [TestMethod]
        public void MatchesAllProperties()
        {
            var item = ItemFactory.GetDefault((decimal)21.50);
            item.AddProperty("Group", "Shoe");
            item.AddProperty("Group", "Clothes");
            _calculatorEngine.AddItem(item);

            var discount = DiscountFactory.GetAmountDiscount(1);
            var condition = ConditionFactory.GetItemPropertiesCondition();
            condition.MatchAllProperties = true;
            var condition2 = ConditionFactory.GetItemPropertiesCondition("Group", "Clothes");
            condition2.MatchAllProperties = true;
            discount.AddCondition(condition);
            discount.AddCondition(condition2);
            discount.Cumulating = true;
            _calculatorEngine.AddDiscount(discount);

            _calculatorEngine.Execute();

            Assert.AreEqual(item.FinalPrice, (decimal)20.50);
        }

        [TestMethod]
        public void NotAppliedBecauseNotAllPropertiesMatched()
        {
            var item = ItemFactory.GetDefault((decimal)21.50);
            item.AddProperty("Group", "Shoe");
            item.AddProperty("Group", "Decoration");
            _calculatorEngine.AddItem(item);

            var discount = DiscountFactory.GetAmountDiscount(1);

            var condition = ConditionFactory.GetItemPropertiesCondition();
            condition.MatchAllProperties = true;
            var condition2 = ConditionFactory.GetItemPropertiesCondition("Group", "Clothes");
            condition2.MatchAllProperties = true;

            discount.AddCondition(condition);
            discount.AddCondition(condition2);
            discount.Cumulating = true;
            _calculatorEngine.AddDiscount(discount);

            _calculatorEngine.Execute();

            Assert.AreEqual(item.FinalPrice, (decimal)21.50);
        }

        [TestMethod]
        public void AppliedBecauseAnyPropertyMatched()
        {
            var item = ItemFactory.GetDefault((decimal)21.50);
            item.AddProperty("Group", "Shoe");
            item.AddProperty("Group", "Decoration");
            _calculatorEngine.AddItem(item);

            var discount = DiscountFactory.GetAmountDiscount(1);

            var condition = ConditionFactory.GetItemPropertiesCondition();
            condition.MatchAllProperties = false;
            var condition2 = ConditionFactory.GetItemPropertiesCondition("Group", "Decoration");
            condition2.MatchAllProperties = false;

            discount.AddCondition(condition);
            discount.AddCondition(condition2);
            discount.Cumulating = true;
            _calculatorEngine.AddDiscount(discount);

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