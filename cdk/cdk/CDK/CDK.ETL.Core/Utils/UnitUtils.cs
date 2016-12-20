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
    public static class UnitUtils
    {

        public static string GetSeoSlug(string streetAddress, string metroArea, string listingId)
        {   
            return string.Format("{0}, {1}, {2}", streetAddress, metroArea, listingId);
        }

        public static string GetUri(NeighborhoodArea nh, BuildingAddress ba, string listingId)
        {
            return string.Format(@"{0}/{1}/{2}", nh.NeighborhoodAreaUri, ba.StreetAddress, listingId).ToUri();
        }

        public static string GetSeoKeywords(string streetAddress, NeighborhoodArea nh, string listingId)
        {
            return string.Format("{0}, {1}, Sale, Rent, {2}", streetAddress, nh.SeoKeywords, listingId);
        }

        public static string GetSeoMetaDescription(string streetAddress, string city, string neighborhoodName, string transactionType, string price, string lease, string leaseType, DateTime date)
        {

            List<string> sentences = new List<string>();

            sentences.Add(String.Format("The condominium at {0}, {1} in {2} neighborhood", streetAddress, city, neighborhoodName));

            if (!string.IsNullOrEmpty(transactionType))
                sentences.Add(String.Format("is currently {0} and has been available on condodork.com since {1}.", transactionType, date.ToString("dddd, d MMM, yyyy", new CultureInfo("en-US"))));

            if (!string.IsNullOrEmpty(price))
                sentences.Add(String.Format("This property is listed for ${0}.", price));

            if (!string.IsNullOrEmpty(lease))
                sentences.Add(String.Format("This property is listed for ${0} {1}.", lease, leaseType));

            return string.Join(" ", sentences.ToArray());

        }

        public static string GetSeoDescription(string streetAddress, string city, string neighborhoodName, string transactionType, string price, string lease, string leaseType, string type, string beds, string bathrooms, string size, string fee, string feePayment, string parking, DateTime date)
        {

            List<string> sentences = new List<string>();

            sentences.Add(String.Format("The condominium at {0}, {1} in {2} neighborhood", streetAddress, city, neighborhoodName));
            if (!string.IsNullOrEmpty(type))
                sentences.Add(String.Format("is a {0}.", type));

            if (!string.IsNullOrEmpty(transactionType))
                sentences.Add(String.Format("It is currently {0} and has been available on condodork.com since {1}.", transactionType.ToLower(), date.ToString("dddd, d MMM, yyyy", new CultureInfo("en-US"))));

            if (!string.IsNullOrEmpty(price))
                sentences.Add(String.Format("This property is listed for ${0}.", price));

            if (!string.IsNullOrEmpty(lease))
                sentences.Add(String.Format("This property is listed for ${0} {1}.", lease, leaseType));

            if (!string.IsNullOrEmpty(beds) && !string.IsNullOrEmpty(bathrooms))
                sentences.Add(String.Format("{0} has {1} beds, {2} bathrooms", streetAddress, beds, bathrooms));

            if (!string.IsNullOrEmpty(size))
                sentences.Add(String.Format("and is {0}.", size));

            if (!string.IsNullOrEmpty(fee))
                sentences.Add(String.Format("The maintenance fee is ${0} {1}.", fee, feePayment));

            if (!string.IsNullOrEmpty(parking))
            {
                sentences.Add(String.Format("The condo has {0} parking space(s) available.", parking));
            }
            else
            {
                sentences.Add(String.Format("The condo has no parking space available."));
            }

            return string.Join(" ", sentences.ToArray()); ;

        }

        public static string GetSeoTitle(string streetAddress, string metroArea)
        {
            return string.Format("{0}, {1}", streetAddress, metroArea);
        }

        public static string GetSeoCaption(string streetAddress, string metroArea, string listingId)
        {
            return string.Format("{0}, {1}, {2}", streetAddress, metroArea, listingId);
        }
    }
}
