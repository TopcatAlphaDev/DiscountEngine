using System.Linq.Dynamic.Core.Exceptions;
using CalculatorEngine.UnitTests.Fixtures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorEngine.UnitTests.Conditions
{
    [TestClass]
    public class AnyItemCustomConditionTest
    {
        private Library.CalculatorEngine _calculatorEngine;

        [TestInitialize]
        public void Initialize()
        {
            _calculatorEngine = new Library.CalculatorEngine();
        }

        [TestMethod]
        public void DiscountWhenAnyItemHasAPriceAbove25()
        {
            var item = ItemFactory.GetDefault((decimal)21.50);
            item.AddProperty("Group", "Shoe");
            _calculatorEngine.AddItem(item);

            var item2 = ItemFactory.GetDefault((decimal)31.50);
            item2.AddProperty("Group", "Clothes");
            _calculatorEngine.AddItem(item2);

            var discount = DiscountFactory.GetAmountDiscount(5);
            var condition = ConditionFactory.GetItemPropertiesCondition("Group", "Shoe");
            var condition2 = ConditionFactory.GetAnyItemCustomCondition("OriginalPrice > 25");
            condition.AddCondition(condition2);
            discount.AddCondition(condition);
            _calculatorEngine.AddDiscount(discount);

            _calculatorEngine.Execute();

            Assert.AreEqual(item.FinalPrice, (decimal)16.50);
            Assert.AreEqual(item2.FinalPrice, (decimal)31.50);
        }

        [TestMethod]
        public void InvalidQueryThrowsException()
        {
            Assert.ThrowsException<ParseException>(() => ConditionFactory.GetAnyItemCustomCondition("Nonsense > 30"));
        }

        [TestCleanup]
        public void CleanUp()
        {
            _calculatorEngine.Clear();
        }
    }
}