using System.Configuration;

namespace CDK.BusinessLogic.Core.Configuration
{
    /// <summary>
    /// The collection class that will store the list of each element/item that
    /// is returned back from the configuration manager.
    /// </summary>
    [ConfigurationCollection(typeof(DevelopmentAmenitiesElement))]
    public class DevelopmentAmenitiesCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new DevelopmentAmenitiesElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((DevelopmentAmenitiesElement)(element)).Url;
        }

        public DevelopmentAmenitiesElement this[int idx]
        {
            get
            {
                return (DevelopmentAmenitiesElement)BaseGet(idx);
            }
        }
    }
}