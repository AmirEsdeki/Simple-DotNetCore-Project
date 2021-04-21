using StockMarketDP.Abstraction.Entities;

namespace StockMarketDP.Entities.Concrete
{
    class StockLatestPrice : IStockLatestPrice
    {
        public string Ticker { get; set; }
        public string Exchange { get; set; }
        public double LatestPrice { get; set; }
        public double Change { get; set; }
        public double ChangePerc { get; set; }
        public double Marketcap { get; set; }
    }
}
