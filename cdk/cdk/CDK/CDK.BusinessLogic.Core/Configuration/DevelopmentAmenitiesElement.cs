using System.Configuration;

namespace CDK.BusinessLogic.Core.Configuration
{
    /// <summary>
    /// The class that holds onto each element returned by the configuration manager.
    /// </summary>
    public class DevelopmentAmenitiesElement : ConfigurationElement
    {
        [ConfigurationProperty("key", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string Url
        {
            get
            {
                return ((string)(base["key"]));
            }
            set
            {
                base["key"] = value;
            }
        }

        [ConfigurationProperty("value", DefaultValue = "", IsKey = false, IsRequired = false)]
        public string Name
        {
            get
            {
                return ((string)(base["value"]));
            }
            set
            {
                base["value"] = value;
            }
        }
    }
}