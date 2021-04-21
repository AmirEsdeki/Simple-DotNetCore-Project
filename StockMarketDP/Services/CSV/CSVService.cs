using StockMarketDP.Abstraction.Entities;
using StockMarketDP.Abstraction.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StockMarketDP.Services.CSV
{
    public class CSVService : ICSVService
    {
        //takes path to the csv file and a mapper function to map csv file lines to the given type
        //returns a list of given type based on the return type of the mapper function
        public List<T> CSVReader<T>(string path, Func<List<string>, T> mapper) where T : IBaseEntity
        {
            List<string> lines = File.ReadAllLines(path).OfType<string>().ToList();

            //first row has titles and needs to be deleted
            lines.RemoveAt(0);

            var list = new List<T>();

            foreach (string line in lines)
            {
                List<string> columns = line.Split(',').OfType<string>().ToList(); ;
                list.Add(mapper(columns));
            }
            return list;
        }
    }
}
