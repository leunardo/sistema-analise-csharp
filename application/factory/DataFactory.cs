using System.Linq;
using south.domain.constants;
using south.domain.interfaces;
using south.domain.model;

namespace south.application.factory
{
    public static class DataFactory
    {
        public static IData GetInstance(string line)
        {
            var dataArray = line.Split('ç');
            var dataId = dataArray[0];

            if (dataId == DataType.Salesman)
            {
                return new Salesman
                {
                    CPF = dataArray[1],
                    Name = dataArray[2],
                    Salary = double.Parse(dataArray[3])
                };
            }
            else if (dataId == DataType.Client)
            {
                return new Client
                {
                    CNPJ = dataArray[1],
                    Name = dataArray[2],
                    BusinessArea = dataArray[3]
                };
            }
            else if (dataId == DataType.Sales)
            {
                var salesmanName = dataArray[3];
                var items = dataArray[2]
                    .Split(',')
                    .Select(
                        item => ItemFactory.GetInstance(item, salesmanName)
                    );

                return new Sale
                {
                    Id = int.Parse(dataArray[1]),
                    Items = items,
                    SalesmanName = salesmanName
                };
            }

            throw new System.InvalidOperationException("Cannot identify the data type.");
        }
    }
}