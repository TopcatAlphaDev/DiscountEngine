using CalculatorEngine.Models.Items;

namespace CalculatorEngine.UnitTests.Fixtures
{
    public static class ItemFactory
    {
        public static Item GetDefault(decimal originalPrice = 0, decimal purchasePrice = 0, int sortOrder = 0) 
        {
            var randomId = new Random().Next().ToString();
            return new Item(randomId, originalPrice, purchasePrice, sortOrder);
        }

        public static List<Item> GetListOfItems()
        {
            var result = new List<Item>();
            for (var i = 0; i < 10; i++) 
            { 
                result.Add(GetDefault());
            }
            return result;
        }
    }
}
