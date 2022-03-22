using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using SiteParser.Toy;

namespace SiteParser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var toySettings = new ToySettings(2, 5);
            var toyParser = new ToyParser();
            var loader = new HtmlLoader(toySettings);


            var toy = new Parser<string[]>(toyParser, toySettings, loader);

            toy.PageParsing();
            toy.MoreThenOnePagesParsing();

            foreach (var item in toyParser.ToysLinks)
            {
                var itemSettings = new ToySettings(item);
                var itemParser = new ToyParser();
                var itemloader = new HtmlLoader(itemSettings);

                var itemToy = new Parser<string[]>(itemParser, itemSettings, itemloader);

                itemToy.PageParsing();
            }

            toy.
            Console.ReadKey();

        }
    }
}
