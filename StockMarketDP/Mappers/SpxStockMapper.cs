using StockMarketDP.Abstraction.Entities;
using StockMarketDP.Entities.Concrete;
using System.Collections.Generic;

namespace StockMarketDP.Mappers
{
    static class SpxStockMapper
    {
        public static ISpxStock Map(List<string> lines)
        {
            var mappedEntity = new SpxStock()
            {
                Ticker = lines[0],
                Exchange = lines[1],
                Name = lines[2],
                Sector = lines[3]
            };
            return mappedEntity;
        }
    }
}
