using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDK.ETL.Core.Extenstions;
using CDK.DataAccess.Models.cdk;
using CDK.DataAccess.Models.ddf;
using System.Globalization;

namespace CDK.ETL.Core.Utils
{
    public static class BuildingUtils
    {

        public static string GetSeoSlug(string streetAddress, string metroArea)
        {
            return string.Format("{0}, {1}", streetAddress, metroArea);
        }

        public static string GetUri(NeighborhoodArea nh, BuildingAddress ba)
        {
            return string.Format(@"{0}/{1}", nh.NeighborhoodAreaUri, ba.StreetAddress).ToUri();
        }

        public static string GetSeoKeywords(string streetAddress, NeighborhoodArea nh)
        {
            return string.Format("{0}, {1}, Sale, Rent, MLS", streetAddress, nh.SeoKeywords);
        }

        public static string GetSeoMetaDescription(string streetAddress, string city, string neighborhoodName, DateTime date)
        {

            List<string> sentences = new List<string>();

            sentences.Add(String.Format("This building is located at {0}, {1} in {2} neighborhood.", streetAddress, city, neighborhoodName));
            sentences.Add(String.Format("It has been available on condodork.com since {0}.", date.ToString("dddd, d MMM, yyyy", new CultureInfo("en-US"))));

            return string.Join(" ", sentences.ToArray()); 

        }

        public static string GetSeoDescription(string streetAddress, string city, string neighborhoodName, string type, string year, string firePlace, string managementCompany, DateTime date)
        {

            List<string> sentences = new List<string>();

            sentences.Add(String.Format("This building is located at {0}, {1} in {2} neighborhood.", streetAddress, city, neighborhoodName));
            sentences.Add(String.Format("It has been available on condodork.com since {0}.", date.ToString("dddd, d MMM, yyyy", new CultureInfo("en-US"))));

            if (!string.IsNullOrEmpty(type)) 
                sentences.Add(String.Format(@"The building at {0} is a {1}.", streetAddress, type));

            if (!string.IsNullOrEmpty(year))
                sentences.Add(String.Format("It has been built in {0}.", year));

            if (!string.IsNullOrEmpty(firePlace) && firePlace == "True")
            {
                sentences.Add(String.Format("This building has fireplace."));
            }
            else
            {
                sentences.Add(String.Format("This building has no fireplace."));
            }

            if (!string.IsNullOrEmpty(managementCompany))
                sentences.Add(String.Format("The management company for this building is {0}.", managementCompany));

            return string.Join(" ", sentences.ToArray()); ;

        }

        public static string GetSeoTitle(string streetAddress, string metroArea)
        {
            return string.Format("{0}, {1}", streetAddress, metroArea);
        }

        public static string GetSeoCaption(string streetAddress, string metroArea)
        {
            return string.Format("{0}, {1}", streetAddress, metroArea);
        }
    }
}