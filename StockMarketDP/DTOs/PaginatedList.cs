using StockMarketDP.Abstraction.DTOs;
using System.Collections.Generic;

namespace StockMarketDP.DTOs
{
    public class PaginatedList<T> where T : IBaseDTO
    {
        public PaginatedList(List<T> list, int total)
        {
            Data = list;
            Total = total;
        }
        public List<T> Data { get; set; }
        public int Total { get; set; }
    }
}
