using System.Configuration;

namespace SearchEngineApi.Configuration
{
    public class SearchEngineBaseAddress : ConfigurationElement
    {
        [ConfigurationProperty("value", IsRequired = true)]
        public string Value{ 
            get { return (string)this["value"]; }
            set { this["value"] = value; }
        }
    }
}
