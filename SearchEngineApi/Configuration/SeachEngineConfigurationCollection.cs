using System.Configuration;

namespace SearchEngineApi.Configuration
{
    [ConfigurationCollection(typeof(SearchEngineConfiguration), AddItemName = "searchEngine")]
    public class SeachEngineConfigurationCollection : ConfigurationElementCollection
    {
        public SearchEngineConfiguration this[int index]
        {
            get { return (SearchEngineConfiguration)BaseGet(index); }
            set { 
                if (BaseGet(index) != null)
                    BaseRemoveAt(index);

                BaseAdd(index, value);
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new SearchEngineConfiguration();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((SearchEngineConfiguration)element).Id;
        }
    }
}
