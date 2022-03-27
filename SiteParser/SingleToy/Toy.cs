using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using SiteParser.SingleToy;


namespace SiteParser.ToySite
{
    public class Toy
    {
        public string RegionName { get; set; }
        //public List<string> Breadcrumbs { get; set; } = new List<string>();
        public StringBuilder Breadcrumbs { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string OldPrice { get; set; }
        public string Availability { get; set; }
        public string ImageLink { get; set; }
        public string ToyLink { get; set; }
    }
}
