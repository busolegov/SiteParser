using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteParser.SingleToy
{
    public class ToySettings : IParserSettings
    {
        public ToySettings(string link)
        {
            ToyUrl = link;
        }

        public string BaseUrl { get; set; }
        public string Prefix { get; set; }
        public string PagePrefix { get; set; }
        public string ToyUrl { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
    }
}
