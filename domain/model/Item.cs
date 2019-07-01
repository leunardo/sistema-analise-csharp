using south.domain.interfaces;

namespace south.domain.model
{
    public class Item : IData
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string SalesmanName { get; set; }
    }
}