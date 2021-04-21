using System.Text.Json.Serialization;

namespace StockMarketDP.DTOs.Filters
{
    public class LatestPriceFilters
    {
        public string Sector { get; set; }
        public string SortBy { get; set; }
        public string Order { get; set; }

        private int _page;
        public int Page
        {
            get { return _page; }
            set
            {
                if (value < 1)
                {
                    value = 0;
                }
                _page = value;
            }
        }
        public int Size { get; set; }

        internal int Skip
        {
            get
            {
                return (Page - 1) * Size;
            }
        }
    }
}
