using System.Data;
using CalculatorEngine.Library;
using CalculatorEngine.UnitTests.Fixtures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorEngine.UnitTests.Conditions
{
    [TestClass]
    public class LimitedAssignmentTest
    {
        private Library.CalculatorEngine _calculatorEngine;

        [TestInitialize]
        public void Initialize()
        {
            _calculatorEngine = new Library.CalculatorEngine();
        }

        [TestMethod]
        public void AppliedToAllThreeItems()
        {
            var item = ItemFactory.GetDefault((decimal)21.50, (decimal)11.50,0);
            item.AddProperty("Group", "Shoe");
            _calculatorEngine.AddItem(item);

            var item2 = ItemFactory.GetDefault((decimal)22.50, (decimal)11.50,1);
            item2.AddProperty("Group", "Shoe");
            _calculatorEngine.AddItem(item2);

            var item3 = ItemFactory.GetDefault((decimal)23.50, (decimal)11.50,2);
            item3.AddProperty("Group", "Shoe");
            _calculatorEngine.AddItem(item3);

            var discount = DiscountFactory.GetAmountDiscount(5);
            var condition = ConditionFactory.GetLimitedAssignmentCondition(10);
            discount.AddCondition(condition);
            discount.Cumulating = true;
            _calculatorEngine.AddDiscount(discount);

            _calculatorEngine.Execute();

            Assert.AreEqual(item.FinalPrice, (decimal)16.50);
            Assert.AreEqual(item2.FinalPrice, (decimal)17.50);
            Assert.AreEqual(item3.FinalPrice, (decimal)18.50);
        }

        [TestMethod]
        public void AppliedToTheFirstTwoItems()
        {
            var item = ItemFactory.GetDefault((decimal)21.50, (decimal)11.50,0);
            item.AddProperty("Group", "Shoe");
            _calculatorEngine.AddItem(item);

            var item2 = ItemFactory.GetDefault((decimal)22.50, (decimal)11.50,1);
            item2.AddProperty("Group", "Shoe");
            _calculatorEngine.AddItem(item2);

            var item3 = ItemFactory.GetDefault((decimal)23.50, (decimal)11.50,2);
            item3.AddProperty("Group", "Shoe");
            _calculatorEngine.AddItem(item3);

            var discount = DiscountFactory.GetAmountDiscount(5);
            var condition = ConditionFactory.GetLimitedAssignmentCondition(2);
            discount.AddCondition(condition);
            discount.Cumulating = true;
            _calculatorEngine.AddDiscount(discount);

            _calculatorEngine.Execute();

            Assert.AreEqual(item.FinalPrice, (decimal)16.50);
            Assert.AreEqual(item2.FinalPrice, (decimal)17.50);
            Assert.AreEqual(item3.FinalPrice, (decimal)23.50);
        }

        [TestCleanup]
        public void CleanUp()
        {
            _calculatorEngine.Clear();
        }
    }
}