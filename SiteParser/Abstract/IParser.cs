using System.Threading.Tasks;
using AngleSharp.Html.Dom;

namespace SiteParser.Abstract
{
    public interface IParser
    {
        Task ParseProcess(IHtmlDocument document);
    }
}
