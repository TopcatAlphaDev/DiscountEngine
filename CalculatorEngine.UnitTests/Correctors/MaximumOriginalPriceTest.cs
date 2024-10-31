using CalculatorEngine.UnitTests.Fixtures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;

namespace CalculatorEngine.UnitTests.Correctors
{
    [TestClass]
    public class MaximumOriginalPriceTest
    {
        private Library.CalculatorEngine _calculatorEngine;

        [TestInitialize]
        public void Initialize()
        {
            _calculatorEngine = new Library.CalculatorEngine();
        }

        [TestMethod]
        public void CorrectionNotAppliedWhenNoCorrector()
        {
            var item = ItemFactory.GetDefault((decimal)2.50, (decimal)1.50);
            item.AddProperty("Group", "Shoe");
            _calculatorEngine.AddItem(item);

            var discount = DiscountFactory.GetAmountDiscount(-5);
            discount.AddCondition(ConditionFactory.GetItemPropertiesCondition());
            discount.Cumulating = true;
            _calculatorEngine.AddDiscount(discount);

            _calculatorEngine.Execute();

            Assert.AreEqual(item.FinalPrice, (decimal)7.50);
        }

        [TestMethod]
        public void CorrectionApplied()
        {
            var item = ItemFactory.GetDefault((decimal)2.50, (decimal)1.50);
            item.AddProperty("Group", "Shoe");
            _calculatorEngine.AddItem(item);

            var discount = DiscountFactory.GetAmountDiscount(-5);
            discount.AddCondition(ConditionFactory.GetItemPropertiesCondition());
            discount.Cumulating = true;
            _calculatorEngine.AddDiscount(discount);

            var corrector = CorrectorFactory.GetMaximumOriginalPriceCorrector();
            corrector.AddCondition(ConditionFactory.GetItemPropertiesCondition());
            _calculatorEngine.AddCorrector(corrector);

            _calculatorEngine.Execute();

            Assert.AreEqual(item.FinalPrice, (decimal)2.50);
        }

        [TestMethod]
        public void MaximumOriginalPriceWhenNotCummulating()
        {
            var item = ItemFactory.GetDefault((decimal)2.50, (decimal)1.50);
            item.AddProperty("Group", "Shoe");
            _calculatorEngine.AddItem(item);

            var discount = DiscountFactory.GetAmountDiscount(-5);
            discount.AddCondition(ConditionFactory.GetItemPropertiesCondition());
            discount.Cumulating = false;
            _calculatorEngine.AddDiscount(discount);

            _calculatorEngine.Execute();

            Assert.AreEqual(item.FinalPrice, (decimal)2.50);
        }

        [TestCleanup]
        public void CleanUp()
        {
            _calculatorEngine.Clear();
        }
    }
}