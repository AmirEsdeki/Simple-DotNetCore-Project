using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using StockMarketDP.Abstraction.Settings;

namespace StockMarketDP.Settings
{
    public class PathSettings
    {
        public string PathToSpxStocksCsv { get; set; }
        public string PathToLatestPricesCsv { get; set; }

        public class Pathes : IPathes
        {
            private readonly IWebHostEnvironment _webHostEnvironment;
            private readonly IOptions<PathSettings> _pathSettings;

            public Pathes(IWebHostEnvironment webHostEnvironment, IOptions<PathSettings> pathSettings)
            {
                _webHostEnvironment = webHostEnvironment;
                _pathSettings = pathSettings;
            }

            public string PathToSpxStocksCsv => CombineGivenPathWithRoot(_pathSettings.Value.PathToSpxStocksCsv);
            public string PathToLatestPricesCsv => CombineGivenPathWithRoot(_pathSettings.Value.PathToLatestPricesCsv);

            private string CombineGivenPathWithRoot(string path)
            {
                return _webHostEnvironment.ContentRootPath + "/" + path;
            }

        }
    }
}
