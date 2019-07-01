using System.Collections.Generic;
using System.Linq;
using south.domain.model;

namespace south.application.services
{
    public class SalesmanService
    {
        public static Salesman GetWorstSalesman(IEnumerable<Sale> sales, IEnumerable<Salesman> salesmen)
        {
            var salesBySalesman = new Dictionary<string, double>();

            foreach (var sale in sales)
            {
                var totalPrice = SaleService.GetTotalPrice(sale);
                if (salesBySalesman.ContainsKey(sale.SalesmanName))
                {
                    var entry = salesBySalesman[sale.SalesmanName];
                    entry += SaleService.GetTotalPrice(sale);
                } else
                {
                    salesBySalesman.Add(sale.SalesmanName, totalPrice);
                }
            }

            var worstSalesman = salesBySalesman.OrderBy(s => s.Value).First().Key;

            return salesmen.First(s => s.Name == worstSalesman);
        }
    }
}