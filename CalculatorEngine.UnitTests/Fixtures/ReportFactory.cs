using CalculatorEngine.Models.Reports;

namespace CalculatorEngine.UnitTests.Fixtures
{
    public static class ReportFactory
    {
        public static TextReport GetTextReport() 
        {
            var randomId = new Random().Next().ToString();
            return new TextReport(randomId, 0);
        }
    }
}
