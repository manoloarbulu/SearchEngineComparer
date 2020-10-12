using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SearchEngineApi.Configuration;
using SearchEngineApi.Interfaces;

namespace SearchEngineApi.Model
{
    public class JsonSearchEngine : SearchEngine<Task<long>, long>, ISearchEngineLong
    {
        public JsonSearchEngine()
        {
            Type = SearchEngineResultType.Json;
            ContentType = "application/json";
        }

        internal JsonSearchEngine(SearchEngineConfiguration configuration)
            :base(configuration)
        {
            if (configuration.Type != SearchEngineResultType.Json)
                throw new InvalidOperationException("Invalid Configuration Result Type");

            ContentType = "application/json";
        }

        public override async Task<long> GetResults(string query)
        {
            var response = await Run(query);
            var responseObject = JsonConvert.DeserializeObject<JObject>(await response.Content.ReadAsStringAsync());
            var token = responseObject.SelectToken(ResultPath);
            return token != null ? Convert.ToInt64(token.ToString()) : 0;
        }
    }
}
