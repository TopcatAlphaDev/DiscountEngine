using CalculatorEngine.UnitTests.Fixtures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorEngine.UnitTests.Reports
{
    [TestClass]
    public class TextReportTest
    {
        private Library.CalculatorEngine _calculatorEngine;

        [TestInitialize]
        public void Initialize()
        {
            _calculatorEngine = new Library.CalculatorEngine();
        }

        [TestMethod]
        public void ItemReportIsEmtpyWhenNoDiscounts()
        {
            var item = ItemFactory.GetDefault((decimal)2.50, (decimal)1.50);
            item.AddProperty("Group", "Shoe");
            var report = ReportFactory.GetTextReport();
            item.AddReport(report);
            _calculatorEngine.AddItem(item);

            _calculatorEngine.Execute();

            Assert.AreEqual(report.Text, "");
        }

        [TestMethod]
        public void DiscountAddedToReport()
        {
            var item = ItemFactory.GetDefault((decimal)21.50, (decimal)10.50);
            item.AddProperty("Group", "Shoe");
            var report = ReportFactory.GetTextReport();
            item.AddReport(report);
            _calculatorEngine.AddItem(item);

            var discount = DiscountFactory.GetAmountDiscount(5);
            var condition = ConditionFactory.GetItemPropertiesCondition();
            discount.AddCondition(condition);
            _calculatorEngine.AddDiscount(discount);

            _calculatorEngine.Execute();

            Assert.AreEqual(report.Text, $@"Condition ItemPropertiesCondition {condition.Id} is fulfilled
Discount AmountDiscount {discount.Id} applied, resulting in finalprice 16.50
");
        }

        [TestMethod]
        public void CorrectionAddedToReport()
        {
            var item = ItemFactory.GetDefault((decimal)21.50, (decimal)19.50);
            item.AddProperty("Group", "Shoe");
            var report = ReportFactory.GetTextReport();
            item.AddReport(report);
            _calculatorEngine.AddItem(item);

            var discount = DiscountFactory.GetAmountDiscount(10);
            var condition = ConditionFactory.GetItemPropertiesCondition();
            discount.AddCondition(condition);
            _calculatorEngine.AddDiscount(discount);

            var corrector = CorrectorFactory.GetMinimumPurchaseCorrector();
            var condition2 = ConditionFactory.GetItemPropertiesCondition();
            corrector.AddCondition(condition2);
            _calculatorEngine.AddCorrector(corrector);

            _calculatorEngine.Execute();

            Assert.AreEqual(report.Text, $@"Condition ItemPropertiesCondition {condition.Id} is fulfilled
Discount AmountDiscount {discount.Id} applied, resulting in finalprice 11.50
Condition ItemPropertiesCondition {condition2.Id} is fulfilled
Correction MinimumPurchasePriceCorrector {corrector.Id} applied, resulting in finalprice 19.50
");
        }

        [TestMethod]
        public void ValidatorAddedToReport()
        {
            var item = ItemFactory.GetDefault((decimal)21.50, (decimal)19.50);
            item.AddProperty("Group", "Shoe");
            var report = ReportFactory.GetTextReport();
            item.AddReport(report);
            _calculatorEngine.AddItem(item);

            var discount = DiscountFactory.GetAmountDiscount(10);
            var condition = ConditionFactory.GetItemPropertiesCondition();
            discount.AddCondition(condition);
            _calculatorEngine.AddDiscount(discount);

            var validator = ValidatorFactory.GetMinimumValidator(0);
            var condition2 = ConditionFactory.GetItemPropertiesCondition();
            validator.AddCondition(condition2);
            _calculatorEngine.AddValidator(validator);

            _calculatorEngine.Execute();

            Assert.AreEqual(report.Text, $@"Condition ItemPropertiesCondition {condition.Id} is fulfilled
Discount AmountDiscount {discount.Id} applied, resulting in finalprice 11.50
Condition ItemPropertiesCondition {condition2.Id} is fulfilled
Validator AllowedMinimumValidator {validator.Id} applied with allowedMinimum 0 and sortOrder 0
");
        }

        [TestCleanup]
        public void CleanUp()
        {
            _calculatorEngine.Clear();
        }
    }
}