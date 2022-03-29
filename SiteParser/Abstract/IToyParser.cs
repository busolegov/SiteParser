using AngleSharp.Html.Dom;


namespace SiteParser.Abstract
{
    public interface IToyParser
    {
        void ParseProcess(IHtmlDocument document);
    }
}
