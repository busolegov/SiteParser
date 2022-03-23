using System.Collections.Generic;
using SiteParser.SingleToy;


namespace SiteParser.ToySite
{
    public class Toy
    {
        public string RegionName { get; set; }
        public List<string> Breadcrumbs { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string OldPrice { get; set; }
        public string Availability { get; set; }
        public string ImageLink { get; set; }
        public string ToyLink { get; set; }

        public Toy(string link)
        {
            ToyLink = link;
        }

        public void GetInfo()
        {
            var toyParser = new ToyParser();
            var toySettings = new ToySettings(ToyLink);
            var toyHtmlLoader = new HtmlLoader(toySettings);
            var worker = new ParserWorker<string>(toyParser, toySettings, toyHtmlLoader);

            worker.ToyPageInfoParsing();
        }
    }
}
