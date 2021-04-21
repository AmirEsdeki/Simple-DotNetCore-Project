using StockMarketDP.DTOs;
using StockMarketDP.DTOs.Filters;
using System.Collections.Generic;

namespace StockMarketDP.Abstraction.Services
{
    public interface IAggregationService
    {
        PaginatedList<LatestPriceDTO> AggregateLatestPrice(LatestPriceFilters latestPriceFilters);
        LatestTickerDTO AggregateLatestTicker(string ticker);
    }
}
