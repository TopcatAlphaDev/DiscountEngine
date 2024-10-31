using CalculatorEngine.UnitTests.Fixtures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorEngine.UnitTests.Validators
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
        public void NoExceptionWhenNegative()
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
        public void ExceptionWhenMinimumExceeded()
        {
            var item = ItemFactory.GetDefault((decimal)2.50, (decimal)1.50);
            item.AddProperty("Group", "Shoe");
            _calculatorEngine.AddItem(item);

            var discount = DiscountFactory.GetAmountDiscount(5);
            discount.AddCondition(ConditionFactory.GetItemPropertiesCondition());
            _calculatorEngine.AddDiscount(discount);

            var validator = ValidatorFactory.GetMinimumValidator(0);
            validator.AddCondition(ConditionFactory.GetItemPropertiesCondition());
            _calculatorEngine.AddValidator(validator);

            Assert.ThrowsException<InvalidDataException>(_calculatorEngine.Execute);
        }

        [TestCleanup]
        public void CleanUp()
        {
            _calculatorEngine.Clear();
        }
    }
}