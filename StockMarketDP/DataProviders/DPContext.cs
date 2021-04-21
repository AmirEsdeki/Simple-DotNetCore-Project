using StockMarketDP.Abstraction.Entities;
using System.Collections.Generic;

namespace StockMarketDP.DataProviders
{
    public class DPContext
    {
        public List<ISpxStock> SpxStocks { get; set; }
        public List<IStockLatestPrice> StockLatestPrices { get; set; }
    }
}
