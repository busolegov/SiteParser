using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteParser.ToySite
{
    internal class ToyParser : IParser<string>
    {
        public string ParseProcess(IHtmlDocument document)
        {
            var itemAvailability = document.QuerySelector("i.v").GetAttribute("Content");
            Console.WriteLine(itemAvailability);
            var price = document.QuerySelector(".price").GetAttribute("Content");
            Console.WriteLine(price);
            var oldPrice = document.QuerySelector(".oldprice").GetAttribute("Content");
            Console.WriteLine(oldPrice);
            var imageLink = document.QuerySelector("img[src*='.jpg']").GetAttribute("Content");
            Console.WriteLine(imageLink);

            //Items.Add(new Toy
            //{
            //    Availability = itemAvailability,
            //    Price = price,
            //    OldPrice = oldPrice,
            //    ImageLink = imageLink
            //});
            //var list1 = new List<string>();
            //return list1.ToArray();
        }
    }
}
