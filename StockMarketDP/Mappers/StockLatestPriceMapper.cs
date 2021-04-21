using StockMarketDP.Abstraction.Entities;
using StockMarketDP.Entities.Concrete;
using System.Collections.Generic;

namespace StockMarketDP.Mappers
{
    static class StockLatestPriceMapper
    {
        public static IStockLatestPrice Map(List<string> lines)
        {
            var mappedEntity = new StockLatestPrice()
            {
                Ticker = lines[0],
                Exchange = lines[1],
                LatestPrice = double.Parse(lines[2]),
                Change = double.Parse(lines[3]),
                ChangePerc = double.Parse(lines[4]),
                Marketcap = double.Parse(lines[5])
            };
            return mappedEntity;
        }
    }
}
