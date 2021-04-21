namespace StockMarketDP.Abstraction.Entities
{
    public interface IStockLatestPrice : IBaseEntity
    {
        string Ticker { get; set; }
        string Exchange { get; set; }
        double LatestPrice { get; set; }
        double Change { get; set; }
        double ChangePerc { get; set; }
        double Marketcap { get; set; }
    }
}
