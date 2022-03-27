using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SiteParser.ToySite
{
    public class ToyParser : IParser
    {
        public string RegionName { get; set; }
        //public List<string> Breadcrumbs { get; set; } = new List<string>();
        public StringBuilder Breadcrumbs { get; set; } = new StringBuilder();
        public string Name { get; set; }
        public string Price { get; set; }
        public string OldPrice { get; set; }
        public string Availability { get; set; }
        public string ImageLink { get; set; }


        public async Task ParseProcess(IHtmlDocument document)
        {
            await Task.Delay(0);
            //наименование
            Name = document.QuerySelector("h1[itemprop=\"name\"]").GetAttribute("content") ?? "no name";

            //ссылка картинки
            ImageLink = document.QuerySelector("img[src*=\".jpg\"]").GetAttribute("src") ?? "no imagelink";

            //регион
            var region = document.QuerySelector("[data-src=\"#region\"]");
            var regionString = region.TextContent.ToString();
            Regex regex = new Regex(@"\w*[A-Яа-я][-]\w*[A-Яа-я]\w*[A-Яа-я]");
            Match match = regex.Match(regionString);
            RegionName = match.Value;
                       
            //хлебные крошки
            var bread = document.QuerySelectorAll("nav.breadcrumb a[href]");
            //foreach (var item in bread)
            //{
            //    Breadcrumbs.Add(item.TextContent);
            //}

            foreach (var item in bread)
            {
                Breadcrumbs.Append(item);
                Breadcrumbs.Append("/ ");
            }

            //цена
            Price = document.QuerySelector("span.price").TextContent ?? "no price";

            //старая цена
            OldPrice = document.QuerySelector("span.old-price").TextContent ?? "no old price";

            //наличие
            Availability = document.QuerySelector("span.ok").TextContent ?? "not available";
        }
    }
}
