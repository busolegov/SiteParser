using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace testpars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var url = "https://www.toy.ru/catalog/toys-spetstekhnika/childs_play_lvy025_fermerskiy_traktor/";
            //var client = new HttpClient();
            //var response = await client.GetAsync(url);

            string data = "\n < !DOCTYPE html >\n < html >\n < head >\n\t < meta name =\"google-site-verification\" content=\"EYEkzah9Zb5dhHjvo9sE1HAq4e5hQWpkA-uzsO7BkXc\" />\n\t<meta name=\"viewport\" content=\"width=device-width, initial-scale=1, shrink-to-fit=no\">\n\t<meta name=\"mailru-ver...";
            var domParser = new HtmlParser();
            var dom = domParser.ParseDocument(data);

            //string availability = "null";
            //string price = "null";
            //string oldPrice = "null";
            //string imageLink = "null";
            //var availability = dom.QuerySelector("i.v*");
            //Console.WriteLine(availability.ToString());
            var price = dom.QuerySelectorAll("span.price");

            //oldPrice = dom.QuerySelector(".oldprice").GetAttribute("Content");
            //Console.WriteLine(oldPrice);
            //imageLink = dom.QuerySelector("img[src*='.jpg']").GetAttribute("Content");
            //Console.WriteLine(imageLink);
            Console.WriteLine();
        }
    }
}
