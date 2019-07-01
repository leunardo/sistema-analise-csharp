using south.domain.model;

namespace south.application.factory
{
    public static class ItemFactory
    {
        public static Item GetInstance(string itemLine, string salesmanName)
        {
            var item = itemLine
                .Replace("[", "")
                .Replace("]", "");
            var values = item.Split("-");

            return new Item
            {
                Id = int.Parse(values[0]),
                Quantity = int.Parse(values[1]),
                Price = double.Parse(values[2]),
                SalesmanName = salesmanName
            };
        }
    }
}