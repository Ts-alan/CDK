using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using System.Configuration;

namespace CDK.ExternalDataAccess
{
    public class GoogleGeocoderManager
    {

        public const string STATUS_OK = "OK";
        public const string STATUS_ZERO_RESULT = "ZERO_RESULT";

        public static GoogleGeoCodeResponse GeocodeAddress(string address)
        {
            try
            {
                var latLong = new Dictionary<string, decimal>();

                string url = string.Format("http://maps.googleapis.com/maps/api/geocode/json?{0}&address={1}", ConfigurationManager.AppSettings["gooleApiKey"], Uri.EscapeDataString(address));

                using (var webClient = new WebClient())
                {

                    var json = webClient.DownloadString(url);
                    GoogleGeoCodeResponse geo = JsonConvert.DeserializeObject<GoogleGeoCodeResponse>(json);
                    return geo;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format(">>> Can't retieve address from google {0}", e.Message));
                return null;
            }
        }

        public class GoogleGeoCodeResponse
        {
            public results[] results { get; set; }
            public string status { get; set; }
        }

        public class results
        {
            public address_component[] address_components { get; set; }
            public string formatted_address { get; set; }
            public geometry geometry { get; set; }
            public string partial_match { get; set; }
            public string[] types { get; set; }
        }

        public class geometry
        {
            public bounds bounds { get; set; }
            public location location { get; set; }
            public string location_type { get; set; }
            public viewport viewport { get; set; }
        }

        public class bounds
        {
            public northeast northeast { get; set; }
            public southwest southwest { get; set; }
        }

        public class viewport
        {
            public northeast northeast { get; set; }
            public southwest southwest { get; set; }
        }

        public class northeast : location
        {
        }

        public class southwest : location
        {
        }

        public class location
        {
            public decimal lat { get; set; }
            public decimal lng { get; set; }
        }

        public class address_component
        {
            public string long_name { get; set; }
            public string short_name { get; set; }
            public string[] types { get; set; }
        }
    }
}