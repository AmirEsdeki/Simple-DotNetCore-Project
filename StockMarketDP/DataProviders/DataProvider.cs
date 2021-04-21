using StockMarketDP.Abstraction.DataProvider;
using StockMarketDP.Abstraction.Entities;
using StockMarketDP.Abstraction.Services;
using StockMarketDP.Abstraction.Settings;
using StockMarketDP.Mappers;
using System;

namespace StockMarketDP.DataProviders
{
    public class DataProvider : IDataProvider
    {
        private readonly ICSVService _csvService;
        private readonly IPathes _pathSettings;
        private DateTime _lastRead;
        private DPContext _DP;

        public DataProvider(ICSVService csvService, IPathes pathSettings)
        {
            _csvService = csvService;
            _pathSettings = pathSettings;

            //check if _DP is null then read the csv file and return the context
            if (_DP == null)
            {
                _DP = ReadFreshCsvData();
            }
        }



        public DPContext GetCsvData
        {
            get
            {
                //by consuming that the csv file updates every 5 sec
                //we check if its time to read the csv file again or just return the existing read csv
                if ((DateTime.Now - _lastRead).TotalSeconds > 5)
                {
                    _DP = ReadFreshCsvData();
                }

                return _DP;
            }
        }

        private DPContext ReadFreshCsvData()
        {
            _lastRead = DateTime.Now;
            DPContext context = new DPContext();
            context.SpxStocks = _csvService.CSVReader<ISpxStock>
                (_pathSettings.PathToSpxStocksCsv, SpxStockMapper.Map);

            context.StockLatestPrices = _csvService.CSVReader<IStockLatestPrice>
                (_pathSettings.PathToLatestPricesCsv, StockLatestPriceMapper.Map);
            return context;
        }

    }
}
