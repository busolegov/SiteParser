using System;
using AngleSharp.Html.Dom;
using System.Collections.Generic;
using System.Threading.Tasks;
using SiteParser.SingleToy;


namespace SiteParser.ToySite
{
    public class ToySiteParser : IParser
    {
        public List<Toy> toyContainer = new List<Toy>();

        public async Task ParseProcess(IHtmlDocument document)
        {

            var items = document.QuerySelectorAll("meta[itemprop=\"url\"]");

            foreach (var element in items)
            {

                Toy toy = new Toy();

                var link = element.GetAttribute("content");

                var toyParser = new ToyParser();
                var toySettings = new ToySettings(link);
                var toyHtmlLoader = new HtmlLoader(toySettings);
                var worker = new ParserWorker<Toy>(toyParser, toySettings, toyHtmlLoader);

                //worker.ToyPageInfoParsingAsync();

                await Task.Run(() => worker.ToyPageInfoParsingAsync());
                //await worker.ToyPageInfoParsingAsync();

                Console.WriteLine("****************** new toy *******************");

                toy.ImageLink = toyParser.ImageLink;
                Console.WriteLine(toy.ImageLink);

                toy.ToyLink = link;
                Console.WriteLine(toy.ToyLink);

                toy.Breadcrumbs = toyParser.Breadcrumbs;
                //foreach (var item in toy.Breadcrumbs)
                //{
                //    Console.Write($"{item}/ ");
                //}
                Console.WriteLine(toy.Breadcrumbs);

                toy.RegionName = toyParser.RegionName;
                Console.WriteLine(toy.RegionName);

                toy.Name = toyParser.Name;
                Console.WriteLine(toy.Name);

                toy.Price = toyParser.Price;
                Console.WriteLine(toy.Price);

                toy.OldPrice = toyParser.OldPrice;
                Console.WriteLine(toy.OldPrice);

                toy.Availability = toyParser.Availability;
                Console.WriteLine(toy.Availability);

                toyContainer.Add(toy);
                Console.WriteLine(toyContainer.Count);
                Console.WriteLine();
            }
        }
    }
}
