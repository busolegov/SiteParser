using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteParser.Toy
{
    public class ToySettings : IParserSettings
    {
        public ToySettings(int start, int end)
        {
            Start = start;
            End = end;
        }

        public ToySettings(string url)
        {
            SingleToyUrl = url;
        }

        public string SingleToyUrl { get; set; }
        public string BaseUrl { get; set; } = "https://www.toy.ru";
        public string Prefix { get; set; } = "catalog/boy_transport/?filterseccode%5B0%5D=transport";
        public string PagePrefix { get; set; } = "&PAGEN_8=";
        public int Start { get; set; }
        public int End { get; set; }
    }
}
