using System;
using AngleSharp.Html.Dom;
using System.Collections.Generic;
using System.Threading.Tasks;
using SiteParser.Abstract;
using SiteParser.SingleToy;


namespace SiteParser.ToySite
{
    public class ToySiteParser : IParser
    {
        public List<Toy> toyContainer = new List<Toy>();

        public async Task ParseProcessAsync(IHtmlDocument document)
        {
            var items = document.QuerySelectorAll("meta[itemprop=\"url\"]");

            List<Task> tasks = new List<Task>();

            foreach (var element in items)
            {
                Toy toy = new Toy();

                var link = element.GetAttribute("content");

                var toyParser = new ToyParser();
                var toySettings = new ToySettings(link);
                var toyHtmlLoader = new HtmlLoader(toySettings);
                var worker = new ParserWorker<string>(toyParser, toyHtmlLoader);

                tasks.Add(FieldsParsingAsync(worker, toy, toyParser, link));
            }

            await Task.WhenAll(tasks);
        }

        public async Task FieldsParsingAsync(ParserWorker<string> worker, Toy toy, ToyParser toyParser, string link)
        {
            await worker.ToyPageInfoParsingAsync();

            Console.WriteLine($"****** parsed new toy # {(toyContainer.Count)+1} ******");

            toy.ToyLink = link;
            Console.WriteLine($"ToyLink: {toy.ToyLink}");

            toy.Breadcrumbs = toyParser.Breadcrumbs;
            Console.WriteLine($"Breadcrumbs: {toy.Breadcrumbs}");

            toy.ImageLinks = toyParser.ImageLinks;
            Console.WriteLine($"ImageLinks: {toy.ImageLinks}");

            toy.RegionName = toyParser.RegionName;
            Console.WriteLine($"RegionName: {toy.RegionName}");

            toy.Name = toyParser.Name;
            Console.WriteLine($"Name: {toy.Name}");

            toy.Price = toyParser.Price;
            Console.WriteLine($"Price: {toy.Price}");

            toy.OldPrice = toyParser.OldPrice;
            Console.WriteLine($"OldPrice: {toy.OldPrice}");

            toy.Availability = toyParser.Availability;
            Console.WriteLine($"Availability: {toy.Availability}");

            toyContainer.Add(toy);
            Console.WriteLine();
        }
    }
}
