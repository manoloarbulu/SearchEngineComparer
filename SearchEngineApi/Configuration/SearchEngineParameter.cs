using System.Configuration;

namespace SearchEngineApi.Configuration
{
    public class SearchEngineParameter : ConfigurationElement
    {
        [StringValidator(InvalidCharacters = " ~!@#$%^&*()[]{}/;'\"|\\")]
        [ConfigurationProperty("key", IsKey = true, IsRequired = true) ]
        public string Key
        {
            get { return (string)this["key"]; }
            set { this["key"] = value; }
        }

        [ConfigurationProperty("value")]
        public string Value
        {
            get { return (string)this["value"]; }
            set { this["value"] = value; }
        }
    }
}
