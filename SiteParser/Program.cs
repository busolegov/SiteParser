using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SiteParser.ToySite;

namespace SiteParser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var siteParser = new ToySiteParser();
            var siteSettings = new ToySiteSettings(2, 17);
            var linkTask = Task.Run(() =>
            {
                var htmlLoader = new HtmlLoader(siteSettings);

                var worker = new ParserWorker<List<string>>(siteParser, siteSettings, htmlLoader);

                worker.PageParsing();
                worker.OtherPagesParsing();
            });
            linkTask.Wait();
            foreach (var item in siteParser.ToyLinks)
            {
                Console.WriteLine(item);
            }

            var toyInfo = new ToyInfo(siteParser);

            foreach (var link in siteParser.ToyLinks)
            {
                var infoTask = Task.Run(() =>
                {
                    new Toy(link).GetInfo();
                });
            }

            Console.WriteLine();

            Console.ReadKey();

        }
    }
}
