using CalculatorEngine.UnitTests.Fixtures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorEngine.UnitTests.Conditions
{
    [TestClass]
    public class AxtiveDateTime
    {
        private Library.CalculatorEngine _calculatorEngine;

        [TestInitialize]
        public void Initialize()
        {
            _calculatorEngine = new Library.CalculatorEngine();
        }

        [TestMethod]
        public void DiscountAppliedWhenActiveDateTimeWithinDiscountPeriod()
        {
            var item = ItemFactory.GetDefault((decimal)21.50);
            item.AddProperty("Group", "Shoe");
            _calculatorEngine.AddItem(item);

            var discount = DiscountFactory.GetAmountDiscount(5);
            discount.AddCondition(ConditionFactory.GetItemPropertiesCondition());
            discount.AddCondition(ConditionFactory.GetValidActivePeriodCondition());
            _calculatorEngine.AddDiscount(discount);

            _calculatorEngine.Execute();

            Assert.AreEqual(item.FinalPrice, (decimal)16.50);
        }

        [TestMethod]
        public void DiscountNotAppliedWhenDiscountPeriodOutsideActiveDateTime()
        {
            var item = ItemFactory.GetDefault((decimal)21.50);
            item.AddProperty("Group", "Shoe");
            _calculatorEngine.AddItem(item);

            var discount = DiscountFactory.GetAmountDiscount(5);
            discount.AddCondition(ConditionFactory.GetItemPropertiesCondition());
            discount.AddCondition(ConditionFactory.GetInValidActivePeriodCondition());
            _calculatorEngine.AddDiscount(discount);

            _calculatorEngine.Execute();

            Assert.AreEqual(item.FinalPrice, (decimal)21.50);
        }

        [TestMethod]
        public void DiscountNotAppliedWhenActiveDateTimeOutsideDiscountPeriod()
        {
            var item = ItemFactory.GetDefault((decimal)21.50);
            item.AddProperty("Group", "Shoe");
            _calculatorEngine.AddItem(item);

            var discount = DiscountFactory.GetAmountDiscount(5);
            discount.AddCondition(ConditionFactory.GetItemPropertiesCondition());
            discount.AddCondition(ConditionFactory.GetValidActivePeriodCondition());
            _calculatorEngine.AddDiscount(discount);

            _calculatorEngine.SetActiveDateTime(DateTime.Now.AddDays(100));
            _calculatorEngine.Execute();

            Assert.AreEqual(item.FinalPrice, (decimal)21.50);
        }

        [TestCleanup]
        public void CleanUp()
        {
            _calculatorEngine.Clear();
        }
    }
}