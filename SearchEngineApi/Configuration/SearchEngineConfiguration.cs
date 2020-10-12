using System.Configuration;

namespace SearchEngineApi.Configuration
{
    public class SearchEngineConfiguration : ConfigurationElement
    {
        [StringValidator(InvalidCharacters = " ~!@#$%^&*()[]{}/;'\"|\\")]
        [ConfigurationProperty("id", IsRequired = true, IsKey = true)]
        public string Id {
            get { return (string)this["id"]; }
            set { this["id"] = value; }
        }

        [ConfigurationProperty("type", IsRequired = true)]
        public SearchEngineResultType Type {
            get { return (SearchEngineResultType)this["type"]; }
            set { this["type"] = value; }
        }

        [ConfigurationProperty("active", IsRequired = false, DefaultValue = true)]
        public bool Active
        { 
            get { return (bool)this["active"]; }
            set { this["active"] = value; }
        }

        [StringValidator(InvalidCharacters = " ~!@#$%^&*()[]{}/;'\"|\\")]
        [ConfigurationProperty("paramQuery", IsRequired = true)]
        public string ParameterQuery
        { 
            get { return (string)this["paramQuery"]; }
            set { this["paramQuery"] = value; }
        }

        [ConfigurationProperty("resultPath", IsRequired = true)]
        public string ResultPath
        { 
            get { return (string)this["resultPath"]; }
            set { this["resultPath"] = value; }
        }

        [ConfigurationProperty("baseAddress", IsRequired = true)]
        public SearchEngineBaseAddress BaseAddress
        {
            get { return (SearchEngineBaseAddress)this["baseAddress"]; }
            set { this["baseAddress"] = value; }
        }

        [ConfigurationProperty("parameters", IsRequired = true, IsDefaultCollection = true)]
        public SearchEngineParameterCollection Parameters
        {
            get { return (SearchEngineParameterCollection)this["parameters"]; }
            //set { this["parameters"] = value; }
        }
    }
}
