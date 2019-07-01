using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using south.application.factory;
using south.domain.interfaces;
using south.domain.model;

namespace south.application.services
{
    public class FileService
    {
        public static IEnumerable<IData> ReadFile(string filePath)
        {
            return File
                .ReadAllLines(filePath, Encoding.GetEncoding("iso-8859-1"))
                .Select(line => DataFactory.GetInstance(line));
        }

        public static void WriteFile(string outputPath, IEnumerable<IData> dataFromFile)
        {
            var data = ParseDataToWrite(dataFromFile);
            
            using (var stream = File.Create(outputPath))
            {
                stream.Write(Encoding.UTF8.GetBytes(data));
            }
        }

        private static string ParseDataToWrite(IEnumerable<IData> data)
        {
            var sb = new StringBuilder();

            var numberOfClients = data.Where(d => d is Client).Count();

            var salesmen = data.Where(d => d is Salesman).Select(s => (Salesman)s);
            var numberOfSalesmen = salesmen.Count();

            var sales = data.Where(d => d is Sale).Select(s => (Sale)s);
            var mostExpensive = SaleService.GetMostExpensiveSale(sales);

            var worstSalesman = SalesmanService.GetWorstSalesman(sales, salesmen);

            sb.AppendFormat("Number of clients: %d\n", numberOfClients);
            sb.AppendFormat("Number of salesmen: %d\n", numberOfSalesmen);
            sb.AppendFormat("Most Expensive sale ID: %d\n", mostExpensive.Id);
            sb.Append("Worst salesman: ").Append(worstSalesman).AppendLine();

            return sb.ToString();
        }
    }
}