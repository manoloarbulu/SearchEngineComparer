using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchEngineApi.Model;
using SearchEngineApi.Interfaces;
using SearchEngineApi.Configuration;

namespace SearchEngineApi
{
    public static class SearchEngines
    {
        public static List<ISearchEngineLong> AvailableSearchEngines()
        {
            var engines = new List<ISearchEngineLong>();

            foreach(SearchEngineConfiguration configuration in SearchEnginesConfiguration.GetSearchEngines())
            {
                switch (configuration.Type)
                {
                    case SearchEngineResultType.Json:
                        engines.Add(new JsonSearchEngine(configuration));
                        break;
                }
            }

            return engines;
        }
    }
}
