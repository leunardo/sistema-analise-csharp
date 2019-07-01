using south.domain.interfaces;

namespace south.domain.model
{
    public class Client : IData
    {
        public string CNPJ { get; set; }
        public string Name { get; set; }
        public string BusinessArea { get; set; }
    }
}