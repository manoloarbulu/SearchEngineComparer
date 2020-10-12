using System.Configuration;

namespace SearchEngineApi.Configuration
{
    [ConfigurationCollection(typeof(SearchEngineParameter), AddItemName = "parameter")]
    public class SearchEngineParameterCollection : ConfigurationElementCollection
    {
        public SearchEngineParameter this[int index]
        {
            get { return (SearchEngineParameter)BaseGet(index); }
            set { 
                if (BaseGet(index) != null)
                    BaseRemoveAt(index);

                BaseAdd(index, value);
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new SearchEngineParameter();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((SearchEngineParameter)element).Key;
        }
    }
}
