using System.Collections.Generic;
using south.domain.interfaces;

namespace south.domain.model
{
    public class Sale : IData
    {
        public int Id { get; set; }
        public IEnumerable<Item> items { get; set; }
        public string salesmanName { get; set; }
    }
}