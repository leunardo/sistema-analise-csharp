using System.Collections.Generic;
using System.Linq;
using south.domain.model;

namespace south.application.services
{
    public class SaleService
    {
        public static Sale GetMostExpensiveSale(IEnumerable<Sale> sales)
        {
            var totalPriceSales = sales
                .Select(sale => new
                {
                    sale.Id,
                    TotalPrice = GetTotalPrice(sale)
                });

            var max = totalPriceSales.Select(s => s.TotalPrice).Max();
            var id = totalPriceSales.First(s => s.TotalPrice == max).Id;

            return sales.First(s => s.Id == id);
        }

        public static double GetTotalPrice(Sale sale) => sale.Items.Select(i => i.Price * i.Quantity).Sum();

    }
}