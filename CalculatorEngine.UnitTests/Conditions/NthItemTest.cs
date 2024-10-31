using CalculatorEngine.UnitTests.Fixtures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorEngine.UnitTests.Conditions
{
    [TestClass]
    public class NthItemTest
    {
        private Library.CalculatorEngine _calculatorEngine;

        [TestInitialize]
        public void Initialize()
        {
            _calculatorEngine = new Library.CalculatorEngine();
        }

        [TestMethod]
        public void NoDiscountWhenOneItem()
        {
            var item = ItemFactory.GetDefault((decimal)21.50, (decimal)11.50, 0);
            item.AddProperty("Group", "Shoe");
            _calculatorEngine.AddItem(item);

            var discount = DiscountFactory.GetAmountDiscount(5);
            var condition = ConditionFactory.GetNthItemCondition(2);
            discount.AddCondition(condition);
            _calculatorEngine.AddDiscount(discount);

            _calculatorEngine.Execute();

            Assert.AreEqual(item.FinalPrice, (decimal)21.50);
        }

        [TestMethod]
        public void AppliedToSecondItemOnly()
        {
            var item = ItemFactory.GetDefault((decimal)21.50, (decimal)11.50, 0);
            item.AddProperty("Group", "Shoe");
            _calculatorEngine.AddItem(item);

            var item2 = ItemFactory.GetDefault((decimal)22.50, (decimal)11.50, 1);
            item2.AddProperty("Group", "Shoe");
            _calculatorEngine.AddItem(item2);

            var item3 = ItemFactory.GetDefault((decimal)23.50, (decimal)11.50, 2);
            item3.AddProperty("Group", "Shoe");
            _calculatorEngine.AddItem(item3);


            var discount = DiscountFactory.GetAmountDiscount(5);
            var condition = ConditionFactory.GetNthItemCondition(2);
            discount.AddCondition(condition);
            _calculatorEngine.AddDiscount(discount);

            _calculatorEngine.Execute();

            Assert.AreEqual(item.FinalPrice, (decimal)21.50);
            Assert.AreEqual(item2.FinalPrice, (decimal)17.50);
            Assert.AreEqual(item3.FinalPrice, (decimal)23.50);
        }

        [TestMethod]
        public void AppliedOnOnlyOneItemWhenTwoItems()
        {
            var item = ItemFactory.GetDefault((decimal)21.50, (decimal)11.50, 0);
            item.AddProperty("Group", "Shoe");
            _calculatorEngine.AddItem(item);

            var item2 = ItemFactory.GetDefault((decimal)22.50, (decimal)11.50, 1);
            item2.AddProperty("Group", "Voucher");
            _calculatorEngine.AddItem(item2);

            var discount = DiscountFactory.GetAmountDiscount(5);
            var condition = ConditionFactory.GetItemCountCondition(2);
            discount.AddCondition(condition);
            var condition2 = ConditionFactory.GetItemPropertiesCondition();
            discount.AddCondition(condition2);

            _calculatorEngine.AddDiscount(discount);

            _calculatorEngine.Execute();

            Assert.AreEqual(item.FinalPrice, (decimal)16.50);
            Assert.AreEqual(item2.FinalPrice, (decimal)22.50);
        }

        [TestCleanup]
        public void CleanUp()
        {
            _calculatorEngine.Clear();
        }
    }
}