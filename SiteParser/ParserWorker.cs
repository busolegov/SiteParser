using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp.Html.Parser;
using SiteParser.Abstract;
using SiteParser.SingleToy;


namespace SiteParser
{
    public class ParserWorker<T> where T : class
    {
        private IParser _parser;
        private IParserSettings _parserSettings;
        private HtmlLoader _htmlLoader;
        private ToyParser _toyParser;


        public ParserWorker(IParser parser, IParserSettings parserSettings, HtmlLoader htmlLoader)
        {
            _parser = parser;
            _parserSettings = parserSettings;
            _htmlLoader = htmlLoader;
        }

        public ParserWorker(ToyParser parser, IParserSettings parserSettings, HtmlLoader htmlLoader)
        {
            _toyParser = parser;
            _parserSettings = parserSettings;
            _htmlLoader = htmlLoader;
        }


        public async Task PagesParsingAsync()
        {
            for (int i = _parserSettings.Start; i <= _parserSettings.End; i++)
            {
                var data = await _htmlLoader.GetPageDataByIdAsync(i);
                var domParser = new HtmlParser();
                var doc = await domParser.ParseDocumentAsync(data);
                await _parser.ParseProcess(doc);
            }
        }


        public async Task ToyPageInfoParsingAsync()
        {
            var data = await _htmlLoader.GetToyPageDataAsync();
            var domParser = new HtmlParser();
            var doc = await domParser.ParseDocumentAsync(data);
            _toyParser.ParseProcess(doc);
        }
    }
}
