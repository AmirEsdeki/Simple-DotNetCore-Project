using StockMarketDP.Abstraction.DTOs;

namespace StockMarketDP.DTOs
{
    public class LatestPriceDTO : IBaseDTO
    {
        public string Ticker { get; set; }
        public string CompanyName { get; set; }
        public string Sector { get; set; }
        public double Marketcap { get; set; }
        public double LatestPrice { get; set; }
        public double LatestChange { get; set; }
    }
}
