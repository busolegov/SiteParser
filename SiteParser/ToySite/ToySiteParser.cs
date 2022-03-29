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

            Console.WriteLine("****************** new toy *******************");

            toy.ToyLink = link;
            Console.WriteLine(toy.ToyLink);

            toy.Breadcrumbs = toyParser.Breadcrumbs;
            Console.WriteLine(toy.Breadcrumbs);

            toy.ImageLinks = toyParser.ImageLinks;
            Console.WriteLine(toy.ImageLinks);

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
