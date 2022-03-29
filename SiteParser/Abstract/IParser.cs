using System.Threading.Tasks;
using AngleSharp.Html.Dom;

namespace SiteParser.Abstract
{
    public interface IParser
    {
        Task ParseProcessAsync(IHtmlDocument document);
    }
}
