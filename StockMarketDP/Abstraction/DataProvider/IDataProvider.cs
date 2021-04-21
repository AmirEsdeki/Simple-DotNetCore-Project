using StockMarketDP.DataProviders;

namespace StockMarketDP.Abstraction.DataProvider
{
    public interface IDataProvider
    {
        public DPContext GetCsvData { get; }
    }
}
