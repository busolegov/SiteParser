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
        private string url;
        private string firstPageUrl;
        private string singleToyUrl;

        public HtmlLoader(IParserSettings settings)
        {
            client = new HttpClient();
            url = $"{settings.BaseUrl}/{settings.Prefix}{settings.PagePrefix}";
            firstPageUrl = $"{settings.BaseUrl}/{settings.Prefix}";
            singleToyUrl = settings.SingleToyUrl;
        }

        public async Task<string> GetPageData()
        {
            var response = await client.GetAsync(firstPageUrl);
            string data = null;

            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                data = await response.Content.ReadAsStringAsync();
            }

            return data;
        }

        public async Task<string> GetPageDataById(int iD)
        {
            var currentUrl = $"{url}{iD.ToString()}";
            var response = await client.GetAsync(currentUrl);
            string data = null;

            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                data = await response.Content.ReadAsStringAsync();
            }

            return data;
        }
    }
}
