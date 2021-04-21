namespace StockMarketDP.Abstraction.Settings
{
    public interface IPathes
    {
        string PathToSpxStocksCsv { get; }
        string PathToLatestPricesCsv { get; }
    }
}