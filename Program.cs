using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;

namespace WikipediaCitiesScrapper
{
    internal class Program
    {
        const string _searchUrl = "https://en.wikipedia.org/w/api.php?action=opensearch&format=json&search=";
        const string _contentUrl = "https://en.wikipedia.org/w/api.php?action=query&prop=revisions&rvprop=content&format=json&titles=";
        const string _municipiosUrl = "https://servicodados.ibge.gov.br/api/v1/localidades/estados/{UF}/municipios/";
        static HttpClient _httpClient;

        static async System.Threading.Tasks.Task Main(string[] args)
        {
            // Todo: Use HttpClientFactory to avoid port exhaustion
            _httpClient = new HttpClient();
            
            var cities = new List<string>();
            var states = new List<string>();

            cities.Add("Rio de Janeiro");
            cities.Add("Valença");

            states.Add("Rio de Janeiro");
            states.Add("Rio de Janeiro");


            for(var index = 0; index < cities.Count; index++)
            {
                var url = $"{_searchUrl}{cities[index]}, {states[index]}";
                var finalurl = await GetCorrectUrlAsync(url);

                //var portugueseUrl = GetPortuguesePage(finalurl);
                var aaa = finalurl.Substring( finalurl.IndexOf("interwiki-pt"));

                var htmlContent = await GetContentAsync(finalurl);
                var flagLink = GetFlagLink(htmlContent);

            }
        }

        static async System.Threading.Tasks.Task<string> GetCorrectUrlAsync(string url)
        {
            var result = await _httpClient.GetAsync(url);

            var contentStream = await result.Content.ReadAsStreamAsync();

            using var streamReader = new StreamReader(contentStream);
            using var jsonReader = new JsonTextReader(streamReader);

            var serializer = new JsonSerializer();

            try
            {
                var aaaa = serializer.Deserialize<dynamic[]>(jsonReader);
                return aaaa[3][0].Value;
            }
            catch(JsonReaderException)
            {
                Console.WriteLine("Invalid JSON.");
                return null;
            } 
        }

        static async System.Threading.Tasks.Task<string> GetContentAsync(string url)
        {
            return await _httpClient.GetStringAsync(url);
        }

        static string GetFlagLink(string htmlContent)
        {
            var aaa = htmlContent.Substring(htmlContent.IndexOf("Flag of"));
            var bbb  = aaa.Substring(aaa.IndexOf(@"src=""") + 5);
            return bbb.Substring(0, bbb.IndexOf('"'));
        }

        static string GetPortuguesePage(string page)
        {
            var aaa = page.Substring( page.IndexOf("interwiki-pt"));
            return "";
        }
    }
}