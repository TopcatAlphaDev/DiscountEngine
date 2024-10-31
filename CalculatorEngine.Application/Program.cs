namespace CalculatorEngine.Application
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calculator engine, calculates final prices after manipulation!");

            var calculatorEngine = new Library.CalculatorEngine();
            //calculatorEngine.AddItemsToCalculate();
            calculatorEngine.Execute();
        }
    }
}