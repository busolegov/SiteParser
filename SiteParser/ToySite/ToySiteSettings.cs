using SiteParser.Abstract;


namespace SiteParser.ToySite
{
    public class ToySiteSettings : IParserSettings
    {
        public ToySiteSettings(int start, int end)
        {
            Start = start;
            End = end;
        }

        public string BaseUrl { get; set; } = "https://www.toy.ru";
        public string Prefix { get; set; } = "catalog/boy_transport/?filterseccode%5B0%5D=transport";
        public string PagePrefix { get; set; } = "&PAGEN_8=";
        public int Start { get; set; }
        public int End { get; set; }
    }
}
