using System.Configuration;

namespace CDK.BusinessLogic.Core.Configuration
{
    public class DevelopmentAmenitiesConfigHelper : ConfigurationSection
    {
        /// <summary>
        /// The value of the property here "Folders" needs to match that of the config file section
        /// </summary>
        [ConfigurationProperty("DevelopmentAmenitiesKeys")]
        public DevelopmentAmenitiesCollection Keys
        {
            get
            {
                return ((DevelopmentAmenitiesCollection)(base["DevelopmentAmenitiesKeys"]));
            }
        }
    }
}