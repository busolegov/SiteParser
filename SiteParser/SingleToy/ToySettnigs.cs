using SiteParser.Abstract;


namespace SiteParser.SingleToy
{
    public class ToySettings : IToyParserSettings
    {
        public string ToyUrl { get; set; }

        public ToySettings(string link)
        {
            ToyUrl = link;
        }
    }
}
