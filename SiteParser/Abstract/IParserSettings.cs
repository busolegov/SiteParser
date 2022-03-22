using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteParser
{
    public interface IParserSettings
    {
        string BaseUrl { get; set; }
        string Prefix { get; set; }
        string PagePrefix { get; set; }
        string SingleToyUrl { get; set; }
        int Start { get; set; }
        int End { get; set; }
    }
}
