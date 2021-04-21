namespace StockMarketDP.Abstraction.Entities
{
    public interface ISpxStock : IBaseEntity
    {
        string Ticker { get; set; }
        string Exchange { get; set; }
        string Name { get; set; }
        string Sector { get; set; }
    }
}
