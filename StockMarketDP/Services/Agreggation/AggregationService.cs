using StockMarketDP.Abstraction.DataProvider;
using StockMarketDP.Abstraction.Services;
using StockMarketDP.DTOs;
using StockMarketDP.DTOs.Filters;
using StockMarketDP.Exeptions;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;

namespace StockMarketDP.Services.Agreggation
{
    public class AggregationService : IAggregationService
    {
        private readonly IDataProvider _dp;

        public AggregationService(IDataProvider dp)
        {
            _dp = dp;
        }
        public PaginatedList<LatestPriceDTO> AggregateLatestPrice(LatestPriceFilters latestPriceFilters)
        {
            var query = from slp in _dp.GetCsvData.StockLatestPrices
                        join spx in _dp.GetCsvData.SpxStocks
                        on slp.Ticker equals spx.Ticker
                        select new LatestPriceDTO
                        {
                            Ticker = slp.Ticker,
                            CompanyName = spx.Name,
                            Sector = spx.Sector,
                            LatestChange = slp.Change,
                            LatestPrice = slp.LatestPrice,
                            Marketcap = slp.Marketcap
                        };

            if (latestPriceFilters.Sector != null)
            {
                query = query.Where(q => q.Sector == latestPriceFilters.Sector);
            }
            
            PropertyInfo sortByProperty;

            if (latestPriceFilters.SortBy != null)
            {
                sortByProperty
                    = typeof(LatestPriceDTO).GetProperty(latestPriceFilters.SortBy, BindingFlags.Public | BindingFlags.Instance);
            }
            else
            {
                sortByProperty
                    = typeof(LatestPriceDTO).GetProperty("Ticker", BindingFlags.Public | BindingFlags.Instance);
            }

            if (latestPriceFilters.Order == "asc" || latestPriceFilters.Order == null)
                query = query.OrderBy(x => sortByProperty.GetValue(x)).ToList();
            else
                query = query.OrderByDescending(x => sortByProperty.GetValue(x)).ToList();
            
            var total = query.ToList().Count;

            if (latestPriceFilters.Size != 0 && latestPriceFilters.Page != 0)
            {
                query = query.Skip(latestPriceFilters.Skip).Take(latestPriceFilters.Size);
            }
            var sortedList = query.ToList();
            return new PaginatedList<LatestPriceDTO>(sortedList, total);
        }
        public LatestTickerDTO AggregateLatestTicker(string ticker)
        {

            var query = from slp in _dp.GetCsvData.StockLatestPrices
                        join spx in _dp.GetCsvData.SpxStocks
                        on slp.Ticker equals spx.Ticker
                        where slp.Ticker.ToLower() == ticker.ToLower()
                        select new LatestTickerDTO
                        {
                            Ticker = slp.Ticker,
                            CompanyName = spx.Name,
                            Sector = spx.Sector,
                            LatestChange = slp.Change,
                            LatestPrice = slp.LatestPrice,
                            Marketcap = slp.Marketcap,
                            Exchange = spx.Exchange
                        };

            var latestTicker = query.FirstOrDefault();

            if (latestTicker == null)
            {
                throw new HttpStatusException(HttpStatusCode.NotFound, "Sorry!! the given ticker is not valid.");
            }

            return latestTicker;
        }
    }
}
