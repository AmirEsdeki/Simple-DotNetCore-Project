using StockMarketDP.Abstraction.Entities;

namespace StockMarketDP.Entities.Concrete
{
    public class SpxStock : ISpxStock
    {
        public string Ticker { get; set; }
        public string Exchange { get; set; }
        public string Name { get; set; }
        public string Sector { get; set; }
    }
}
