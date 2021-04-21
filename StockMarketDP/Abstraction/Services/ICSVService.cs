using StockMarketDP.Abstraction.Entities;
using System;
using System.Collections.Generic;

namespace StockMarketDP.Abstraction.Services
{
    public interface ICSVService
    {
        List<T> CSVReader<T>(string path, Func<List<string>, T> mapper) where T : IBaseEntity;
    }
}
