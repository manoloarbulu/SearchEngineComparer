using System.Configuration;

namespace SearchEngineApi.Configuration
{
    public static class SearchEnginesConfiguration
    {
        public static SearchEnginesConfigurationSection _config = ConfigurationManager.GetSection("searchEnginesConfig") as SearchEnginesConfigurationSection;
        public static SeachEngineConfigurationCollection GetSearchEngines()
        {
            return _config.SearchEngines;
        }
    }
}
