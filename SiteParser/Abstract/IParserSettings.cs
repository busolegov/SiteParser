namespace SiteParser.Abstract
{
    public interface IParserSettings
    {
        string BaseUrl { get; set; }
        string Prefix { get; set; }
        string PagePrefix { get; set; }
        string ToyUrl { get; set; }
        int Start { get; set; }
        int End { get; set; }
    }
}
