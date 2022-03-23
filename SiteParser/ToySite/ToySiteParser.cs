using AngleSharp.Html.Dom;
using System.Collections.Generic;


namespace SiteParser.ToySite
{
    public class ToySiteParser : IParser<List<string>>
    {
        public List<string> ToyLinks { get; set; } = new List<string>();

        public List<string> ParseProcess(IHtmlDocument document)
        {
            var list = new List<string>();

            var items = document.QuerySelectorAll("meta[content^='https://www.toy.ru/catalog/']");

            foreach (var element in items)
            {
                ToyLinks.Add(element.GetAttribute("Content"));
            }
            return ToyLinks;
        }
    }
}
