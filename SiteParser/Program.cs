using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using SiteParser.ToySite;


namespace SiteParser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var siteParser = new ToySiteParser();
                var siteSettings = new ToySiteSettings(1, 17);
                var htmlLoader = new HtmlLoader(siteSettings);
                var worker = new ParserWorker<List<string>>(siteParser, siteSettings, htmlLoader);

                Console.WriteLine("Parsing start...");
                var task = worker.PagesParsingAsync();
                Task.WaitAll(task);

                Console.WriteLine("Parsing end.");
                Console.WriteLine();

                using (var textWriter = new StreamWriter(@"D:\toyinfo.csv", false, Encoding.UTF8))
                {
                    var writer = new CsvWriter(textWriter, CultureInfo.CurrentCulture, false);

                    writer.WriteField("RegionName");
                    writer.WriteField("Breadcrumbs");
                    writer.WriteField("Name");
                    writer.WriteField("Price");
                    writer.WriteField("OldPrice");
                    writer.WriteField("Availability");
                    writer.WriteField("ImageLinks");
                    writer.WriteField("ToyLink");

                    writer.NextRecord();

                    foreach (var item in siteParser.toyContainer)
                    {
                        writer.WriteField(item.RegionName);
                        writer.WriteField(item.Breadcrumbs);
                        writer.WriteField(item.Name);
                        writer.WriteField(item.Price);
                        writer.WriteField(item.OldPrice);
                        writer.WriteField(item.Availability);
                        writer.WriteField(item.ImageLinks);
                        writer.WriteField(item.ToyLink);

                        writer.NextRecord();
                    }
                }

                Console.WriteLine("Csv file is ready.");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
