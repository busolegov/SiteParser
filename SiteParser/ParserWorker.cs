﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Html.Parser;

namespace SiteParser
{
    public class ParserWorker<T> where T : class
    {
        private IParser<T> _parser;
        private IParserSettings _parserSettings;
        private HtmlLoader _htmlLoader;


        public ParserWorker(IParser<T> parser, IParserSettings parserSettings, HtmlLoader htmlLoader)
        {
            _parser = parser;
            _parserSettings = parserSettings;
            _htmlLoader = htmlLoader;
        }

        public async void PageParsing()
        {
            var data = await _htmlLoader.GetPageData();
            var domParser = new HtmlParser();

            var doc = await domParser.ParseDocumentAsync(data);

            var result = _parser.ParseProcess(doc);
        }

        public async void OtherPagesParsing()
        {
            for (int i = _parserSettings.Start; i <= _parserSettings.End; i++)
            {
                var data = await _htmlLoader.GetPageDataById(i);
                var domParser = new HtmlParser();

                var doc = await domParser.ParseDocumentAsync(data);

                var result = _parser.ParseProcess(doc);
            }
        }

        public async void ToyPageInfoParsing()
        {
            var data = await _htmlLoader.GetToyPageData();
            var domParser = new HtmlParser();

            var doc = await domParser.ParseDocumentAsync(data);

            var result = _parser.ParseProcess(doc);
        }
    }
}