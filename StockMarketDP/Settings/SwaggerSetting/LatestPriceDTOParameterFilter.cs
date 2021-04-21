using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StockMarketDP.Settings.SwaggerSetting
{
    public class LatestPriceDTOParameterFilter : IParameterFilter
    {
        public void Apply(OpenApiParameter parameter, ParameterFilterContext context)
        {
            if (parameter.Name.Equals("SortBy", StringComparison.InvariantCultureIgnoreCase))
            {

                IEnumerable<String> SortColumns = new List<string>
                {
                    "Ticker",
                    "CompanyName",
                    "Sector",
                    "Marketcap",
                    "LatestPrice",
                    "LatestChange",
                };

                parameter.Schema.Enum = SortColumns.Select(x => new OpenApiString(x)).ToList<IOpenApiAny>();
            }
            if (parameter.Name.Equals("Order", StringComparison.InvariantCultureIgnoreCase))
            {

                IEnumerable<String> SortColumns = new List<string>
                {
                    "asc",
                    "desc"
                };

                parameter.Schema.Enum = SortColumns.Select(x => new OpenApiString(x)).ToList<IOpenApiAny>();
            }
        }
    }
}
