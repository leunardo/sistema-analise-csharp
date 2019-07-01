using south.domain.interfaces;

namespace south.domain.model
{
    public class Salesman : IData
    {
        public string CPF { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }

        public override string ToString() => $"{Name} - CPF: {CPF} - Salary: {Salary}";
    }
}