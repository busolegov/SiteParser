using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Html.Parser;
using SiteParser.ToySite;

namespace SiteParser
{
    public class ParserWorker<T> where T : class
    {
        private IParser _parser;
        private IParserSettings _parserSettings;
        private HtmlLoader _htmlLoader;


        public ParserWorker(IParser parser, IParserSettings parserSettings, HtmlLoader htmlLoader)
        {
            _parser = parser;
            _parserSettings = parserSettings;
            _htmlLoader = htmlLoader;
        }

        public async Task PageParsingAsync()
        {
            var data = await _htmlLoader.GetPageDataAsync();
            var domParser = new HtmlParser();
            var doc = await domParser.ParseDocumentAsync(data);

            _parser.ParseProcess(doc);

        }

        public async Task PagesParsingAsync()
        {
            for (int i = _parserSettings.Start; i <= _parserSettings.End; i++)
            {
                var data = await _htmlLoader.GetPageDataByIdAsync(i);
                var domParser = new HtmlParser();

                var doc = await domParser.ParseDocumentAsync(data);
                await Task.Run(() => _parser.ParseProcess(doc));

                //_parser.ParseProcess(doc);
            }

        }

        public async Task ToyPageInfoParsingAsync()
        {
            var data = await _htmlLoader.GetToyPageDataAsync();
            var domParser = new HtmlParser();

            var doc = await domParser.ParseDocumentAsync(data);

            await _parser.ParseProcess(doc);
            
            //_parser.ParseProcess(doc);
        }
    }
}
