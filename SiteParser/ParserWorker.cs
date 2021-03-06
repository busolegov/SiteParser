using System.Threading.Tasks;
using AngleSharp.Html.Parser;
using SiteParser.Abstract;


namespace SiteParser
{
    public class ParserWorker<T> where T : class
    {
        private IParser _parser;
        private IParserSettings _parserSettings;
        private IToyParser _toyParser;
        private HtmlLoader _htmlLoader;

        public ParserWorker(IParser parser, IParserSettings parserSettings, HtmlLoader htmlLoader)
        {
            _parser = parser;
            _parserSettings = parserSettings;
            _htmlLoader = htmlLoader;
        }

        public ParserWorker(IToyParser parser, HtmlLoader htmlLoader)
        {
            _toyParser = parser;
            _htmlLoader = htmlLoader;
        }

        public async Task PagesParsingAsync()
        {
            for (int i = _parserSettings.Start; i <= _parserSettings.End; i++)
            {
                var data = await _htmlLoader.GetPageDataByIdAsync(i);
                var domParser = new HtmlParser();
                var doc = await domParser.ParseDocumentAsync(data);
                await _parser.ParseProcessAsync(doc);
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
