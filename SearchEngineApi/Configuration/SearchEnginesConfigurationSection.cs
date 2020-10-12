using System.Configuration;
namespace SearchEngineApi.Configuration
{
    public class SearchEnginesConfigurationSection: ConfigurationSection
    {
        [ConfigurationProperty("searchEngines", IsDefaultCollection = true)]
        public SeachEngineConfigurationCollection SearchEngines
        {
            get { return (SeachEngineConfigurationCollection)this["searchEngines"]; }
        }
    }
}
