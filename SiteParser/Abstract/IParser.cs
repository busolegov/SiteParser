using System.Threading.Tasks;
using AngleSharp.Html.Dom;

namespace SiteParser
{
    public interface IParser
    {
        Task ParseProcess(IHtmlDocument document);
    }
}
