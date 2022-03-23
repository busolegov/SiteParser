using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SiteParser
{
    public class HtmlLoader
    {
        private readonly HttpClient client;
        private string _url;
        private string _firstPageUrl;
        private string _toyUrl;

        public HtmlLoader(IParserSettings settings)
        {
            client = new HttpClient();
            _url = $"{settings.BaseUrl}/{settings.Prefix}{settings.PagePrefix}";
            _firstPageUrl = $"{settings.BaseUrl}/{settings.Prefix}";
            _toyUrl = settings.ToyUrl;
        }

        public async Task<string> GetPageData()
        {
            var response = await client.GetAsync(_firstPageUrl);
            string data = null;

            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                data = await response.Content.ReadAsStringAsync();
            }

            return data;
        }

        public async Task<string> GetPageDataById(int iD)
        {
            var currentUrl = $"{_url}{iD.ToString()}";
            var response = await client.GetAsync(currentUrl);
            string data = null;

            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                data = await response.Content.ReadAsStringAsync();
            }

            return data;
        }

        public async Task<string> GetToyPageData()
        {
            var response = await client.GetAsync(_toyUrl);
            string data = null;

            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                data = await response.Content.ReadAsStringAsync();
            }

            return data;
        }
    }
}
