using AngleSharp.Html.Dom;

namespace SiteParser
{
    public interface IParser<T> where T : class
    {
        T ParseProcess(IHtmlDocument document);
    }
}
