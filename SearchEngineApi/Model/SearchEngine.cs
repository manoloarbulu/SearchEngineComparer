using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web;
using System.Net.Http.Headers;
using SearchEngineApi.Interfaces;
using SearchEngineApi.Configuration;

namespace SearchEngineApi.Model
{
    public abstract class SearchEngine<T, K>: ISearchEngine<K> where T: Task<K>
    {
        public string Id { get; protected set; }
        public string BaseAddress { get; protected set; }
        public Dictionary<string, string> Parameters { get; protected set; }
        public string ParameterQuery { get; protected set; }
        public string ResultPath { get; protected set; }
        public SearchEngineResultType Type { get; protected set; }
        public bool Active { get; protected set; }
        public string ContentType { get; protected set; }

        public SearchEngine()
        {
            Parameters = new Dictionary<string, string>();
        }

        protected SearchEngine(SearchEngineConfiguration configuration)
            : this()
        {
            Id = configuration.Id;
            BaseAddress = configuration.BaseAddress.Value;
            ParameterQuery = configuration.ParameterQuery;
            ResultPath = configuration.ResultPath;
            Type = configuration.Type;
            Active = configuration.Active;

            foreach(SearchEngineParameter parameter in configuration.Parameters)
            {
                Parameters[parameter.Key] = parameter.Value;
            }
        }

        protected async Task<HttpResponseMessage> Run (string query)
        {
            using(HttpClient client = new HttpClient(new HttpClientHandler() { AutomaticDecompression = System.Net.DecompressionMethods.Deflate | System.Net.DecompressionMethods.GZip }))
            {
                var parameters = HttpUtility.ParseQueryString(string.Empty);
                foreach(string key in  Parameters.Keys)
                { 
                    parameters[key] = Parameters[key];
                }

                parameters[ParameterQuery] = query;

                var uri = new UriBuilder(BaseAddress)
                {
                    Query = parameters.ToString()
                };

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(ContentType));

                return await client.GetAsync(uri.Uri);
            }
        }

        public abstract Task<K> GetResults(string query);
    }
}
