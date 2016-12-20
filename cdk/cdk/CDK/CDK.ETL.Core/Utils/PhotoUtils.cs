using CDK.DataAccess.Models.cdk;
using CDK.DataAccess.Models.ddf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CDK.ETL.Core.Extenstions;

namespace CDK.ETL.Core.Utils
{
    class PhotoUtils
    {

        public const string ThumbNailPhotoAlias = "ThumbnailPhoto";
        public const string SmallPhotoAlias = "Photo";
        public const string LargePhotoAlias = "LargePhoto";

        public static string GetSeoSlug(string streetAddress, string metroArea, string listingId)
        {
            return string.Format("{0}, {1}, {2}", streetAddress, metroArea, listingId);
        }

        public static string GetThumbnailUri(string unitUri, string buildingAddress, string listingId, string sequence)
        {
            string photoName = string.Format(@"{0}/thumbnail/{1}-{2}", unitUri, buildingAddress.ToSlug(), sequence).ToUri();
            return string.Format("{0}.jpg", photoName);
        }

        public static string GetSmallUri(string unitUri, string buildingAddress, string listingId, string sequence)
        {
            string photoName = string.Format(@"{0}/small/{1}-{2}", unitUri, buildingAddress.ToSlug(), sequence).ToUri();
            return string.Format("{0}.jpg", photoName);
        }

        public static string GetLargeUri(string unitUri, string buildingAddress, string listingId, string sequence)
        {
            string photoName = string.Format(@"{0}/large/{1}-{2}", unitUri, buildingAddress.ToSlug(), sequence).ToUri();
            return string.Format("{0}.jpg", photoName);
        }

        public static string GetOfficeThumbnailLogoUri(string name)
        {
            string photoName = string.Format(@"thumbnail/{0}-{1}", name, GenerateRandomString(2)).ToUri();
            return string.Format("{0}.jpg", photoName);
        }

        public static string GetAgentThumbnailLogoUri(string name)
        {
            string photoName = string.Format(@"thumbnail/{0}-{1}", name, GenerateRandomString(2)).ToUri();
            return string.Format("{0}.jpg", photoName);
        }

        public static string GetAgentLargeLogoUri(string name)
        {
            string photoName = string.Format(@"large/{0}-{1}", name, GenerateRandomString(2)).ToUri();
            return string.Format("{0}.jpg", photoName);
        }

        public static string GetAlternateText()
        {
            return "";
        }

        public static string GetSeoKeywords(string streetAddress, NeighborhoodArea nh, string listingId)
        {
            return string.Format("{0}, {1}, Sale, Rent, {2}", streetAddress, nh.SeoKeywords, listingId);
        }

        public static string GetSeoMetaDescription()
        {
            return "";
        }

        public static string GetGeneratedDescription()
        {
            return "";
        }

        public static string GetSeoDescription()
        {
            return "";
        }

        public static string GetSeoTitle(string streetAddress, string metroArea)
        {
            return string.Format("{0}, {1}", streetAddress, metroArea);
        }

        public static string GetSeoCaption(string streetAddress, string metroArea, string listingId)
        {
            return string.Format("{0}, {1}, {2}", streetAddress, metroArea, listingId);
        }

        private static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
