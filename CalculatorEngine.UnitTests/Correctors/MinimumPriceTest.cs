using System.Data;
using CalculatorEngine.Library;
using CalculatorEngine.UnitTests.Fixtures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorEngine.UnitTests.Correctors
{
    [TestClass]
    public class AllowedMinimumTest
    {
        private Library.CalculatorEngine _calculatorEngine;

        [TestInitialize]
        public void Initialize()
        {
            _calculatorEngine = new Library.CalculatorEngine();
        }

        [TestMethod]
        public void CorrectionNotApplieApplied()
        {
            var item = ItemFactory.GetDefault((decimal)2.50, (decimal)1.50);
            item.AddProperty("Group", "Shoe");
            _calculatorEngine.AddItem(item);

            var discount = DiscountFactory.GetAmountDiscount(5);
            discount.AddCondition(ConditionFactory.GetItemPropertiesCondition());
            _calculatorEngine.AddDiscount(discount);

            _calculatorEngine.Execute();

            Assert.AreEqual(item.FinalPrice, (decimal)-2.50);
        }

        [TestMethod]
        public void CorrectionApplieApplied()
        {
            var item = ItemFactory.GetDefault((decimal)2.50, (decimal)1.50);
            item.AddProperty("Group", "Shoe");
            _calculatorEngine.AddItem(item);

            var discount = DiscountFactory.GetAmountDiscount(5);
            discount.AddCondition(ConditionFactory.GetItemPropertiesCondition());
            _calculatorEngine.AddDiscount(discount);

            var corrector = CorrectorFactory.GetMinimumCorrector(0);
            corrector.AddCondition(ConditionFactory.GetItemPropertiesCondition());
            _calculatorEngine.AddCorrector(corrector);

            _calculatorEngine.Execute();

            Assert.AreEqual(item.FinalPrice, (decimal)0);
        }

        [TestCleanup]
        public void CleanUp()
        {
            _calculatorEngine.Clear();
        }
    }
}