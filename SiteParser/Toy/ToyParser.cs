using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;

namespace SiteParser.Toy
{
    public class ToyParser : IParser<string[]>
    {
        public List<string> ToysLinks { get; set; } = new List<string>();
        public string[] Parse(IHtmlDocument document)
        {
            var list = new List<string>();

            var items = document.QuerySelectorAll("meta[content^='https://www.toy.ru/catalog/']");

            foreach (var item in items)
            {
                ToysLinks.Add(item.GetAttribute("Content"));
                Console.WriteLine($"{ToysLinks.Count}{item.GetAttribute("Content")}");
            }
            return list.ToArray();
        }
    }
}
