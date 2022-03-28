using AngleSharp.Html.Dom;
using System.Text;
using System.Text.RegularExpressions;


namespace SiteParser.SingleToy
{
    public class ToyParser
    {
        public string RegionName { get; set; }
        public StringBuilder Breadcrumbs { get; set; } = new StringBuilder();
        public string Name { get; set; }
        public string Price { get; set; }
        public string OldPrice { get; set; }
        public string Availability { get; set; }
        public StringBuilder ImageLinks { get; set; } = new StringBuilder();
        public string ImageLink { get; set; }


        public void ParseProcess(IHtmlDocument document)
        {

            //наименование
            Name = document.QuerySelector("h1[itemprop=\"name\"]").GetAttribute("content") ?? "no name";

            //ссылка картинки
            ImageLink = document.QuerySelector("img.img-fluid").GetAttribute("src");

            var image = document.QuerySelectorAll("img.img-fluid[src*=\"?_cvc\"]");
            foreach (var item in image)
            {
                ImageLinks.Append(item.GetAttribute("src"));
                ImageLinks.Append(", ");
            }

            //регион
            var region = document.QuerySelector("[data-src=\"#region\"]");
            var regionString = region.TextContent.ToString();
            Regex regex = new Regex(@"\w*[A-Яа-я][-]\w*[A-Яа-я]\w*[A-Яа-я]");
            Match match = regex.Match(regionString);
            RegionName = match.Value;
                       
            //хлебные крошки
            var bread = document.QuerySelectorAll("nav.breadcrumb a[href]");
            foreach (var item in bread)
            {
                Breadcrumbs.Append(item.GetAttribute("title"));
                Breadcrumbs.Append("/ ");
            }

            //цена
            Price = document.QuerySelector("span.price").TextContent;

            //старая цена
            var oldPrice = document.QuerySelector("span.old-price");
            if (oldPrice == null)
            {
                OldPrice = "no old price";
            }
            else
            {
                OldPrice = oldPrice.TextContent;
            }

            //наличие
            var availability = document.QuerySelector("span.ok");
            if (availability == null)
            {
                Availability = "not available";
            }
            else
            {
                Availability = availability.TextContent;
            }
        }
    }
}
