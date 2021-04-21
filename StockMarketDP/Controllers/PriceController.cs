using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StockMarketDP.Abstraction.DataProvider;
using StockMarketDP.Abstraction.Services;
using StockMarketDP.DTOs;
using StockMarketDP.DTOs.Filters;
using System.Collections.Generic;

namespace StockMarketDP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PriceController : ControllerBase
    {
        private readonly ILogger<PriceController> _logger;
        private readonly IDataProvider _dp;
        private readonly IAggregationService _aggregationService;

        public PriceController(ILogger<PriceController> logger,
            IDataProvider dp,
            IAggregationService aggregationService)
        {
            _logger = logger;
            _dp = dp;
            _aggregationService = aggregationService;
        }

        [HttpGet]
        [Route("latest/list")]
        public PaginatedList<LatestPriceDTO> List([FromQuery] LatestPriceFilters filters)
        {
            return _aggregationService.AggregateLatestPrice(filters);
        }

        [HttpGet]
        [Route("latest/ticker/{ticker}")]
        public LatestTickerDTO GetTicker(string ticker)
        {
            return _aggregationService.AggregateLatestTicker(ticker);
        }
    }
}
