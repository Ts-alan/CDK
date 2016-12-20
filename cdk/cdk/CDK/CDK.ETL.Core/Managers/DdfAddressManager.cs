using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using CDK.ETL.DDF.DdfRawModel;
using CDK.ExternalDataAccess;
using CDK.ETL.Core.SpecialPocos;

namespace CDK.ETL.Core.Managers
{
    class DdfAddressManager
    {

        List<string> ptrns = null;

        public DdfAddressManager()
        {

            ptrns = new List<string>();

            ptrns.Add(@"(\|(Unit [^\s]+))");
            ptrns.Add(@"(Unit [^\s]+)");
            ptrns.Add(@"#([^\s]+)-");
            ptrns.Add(@"#[^\s]+ [^\s]+-");
            ptrns.Add(@"# ([^\s]+)");
            ptrns.Add(@"#([^\s]+)");
            ptrns.Add(@"([^\s|\|]+)-");
            ptrns.Add(@"([^\s|\|]+) -");
            ptrns.Add(@"([^\s|\|]+) - ");

        }

        public AddressResultPoco TransformAddressFromDdf(Property property)
        {

            StringBuilder sb = null;

            if (property.StreetAddress != null)
            {

                sb = new StringBuilder();

                string timredAddress = property.StreetAddress.Trim();

                AddressResultPoco addressResultPOCO = new AddressResultPoco();

                //Loop for street name
                foreach (string ptrn in ptrns)
                {
                    Regex expression = new Regex(ptrn);

                    if (expression.IsMatch(timredAddress))
                    {

                        var results = expression.Match(timredAddress);

                        string foundResult = results.Groups[0].Value;

                        if (ptrns.IndexOf(ptrn) == ptrns.Count - 1 || ptrns.IndexOf(ptrn) == ptrns.Count - 2)
                        {
                            string[] splitedAddress = timredAddress.Split(' ');
                            foundResult = splitedAddress[0];
                        }

                        timredAddress = timredAddress.Replace(foundResult, "");
                        timredAddress = timredAddress.Trim();

                        if (timredAddress.StartsWith("-"))
                        {
                            timredAddress = timredAddress.Remove(0, 1);
                            timredAddress = timredAddress.Trim();
                        }

                        break;
                    }
                }

                string builtAddress = BuildFullAddress(timredAddress, property.City, property.PostalCode, property.CountryState, property.Country);
                GoogleGeocoderManager.GoogleGeoCodeResponse geoCodedAddress = GoogleGeocoderManager.GeocodeAddress(builtAddress);

                if (geoCodedAddress != null && geoCodedAddress.status == GoogleGeocoderManager.STATUS_OK)
                {

                    bool addressFound = false;
                    int ctrResult = 0;
                    //This manager use an inner class
                    foreach (GoogleGeocoderManager.results result in geoCodedAddress.results)
                    {

                        //Check to find potential match
                        if (result.types != null)
                        {

                            addressFound = false;
                            foreach (string type in result.types)
                            {
                                if (type == "street_address" || type == "premise" || type == "subpremise")
                                {

                                    addressFound = true;

                                    sb = new StringBuilder();

                                    addressResultPOCO = new AddressResultPoco();
                                    addressResultPOCO.FullAddress = geoCodedAddress.results[ctrResult].formatted_address;

                                    foreach (var component in geoCodedAddress.results[ctrResult].address_components)
                                    {
                                        if (component.types[0] == "street_number")
                                        {
                                            sb.Append(component.long_name);
                                        }
                                        if (component.types[0] == "route")
                                        {
                                            sb.Append(" ").Append(component.long_name);
                                        }
                                        if (component.types[0] == "postal_code")
                                        {
                                            addressResultPOCO.PostalCode = component.long_name;
                                        }
                                        if (component.types[0] == "administrative_area_level_1")
                                        {
                                            addressResultPOCO.State = component.long_name;
                                        }
                                        if (component.types[0] == "locality")
                                        {
                                            addressResultPOCO.City = component.long_name;
                                        }
                                    }

                                    addressResultPOCO.StreetAddress = sb.ToString();
                                    addressResultPOCO.Lat = geoCodedAddress.results[ctrResult].geometry.location.lat.ToString().Replace(",", ".");
                                    addressResultPOCO.Lon = geoCodedAddress.results[ctrResult].geometry.location.lng.ToString().Replace(",", ".");
                                    return addressResultPOCO;

                                }
                            }
                            if (!addressFound)
                            {
                                Console.WriteLine("|>>> (Status {0}) ({1}) ({2}) ({3}) <<<|", geoCodedAddress.status, property.StreetAddress, timredAddress, builtAddress);
                            }
                        }

                        ctrResult++;

                    }
                }
                else
                {
                    Console.WriteLine("|>>> (Status {0}) ({1}) ({2}) ({3}) <<<|", geoCodedAddress.status, property.StreetAddress, timredAddress, builtAddress);
                }
            }

            return null;

        }

        private string BuildFullAddress(string streetAddress, string city, string postalCode, string countryState, string country)
        {

            StringBuilder fullAddress = new StringBuilder();
            fullAddress.Append(streetAddress);

            if (city!=null)
            {
                fullAddress.Append(",");
                fullAddress.Append(city);
            }

            if (postalCode != null)
            {
                fullAddress.Append(",");
                fullAddress.Append(postalCode);
            }

            if (countryState != null)
            {
                fullAddress.Append(",");
                fullAddress.Append(countryState);
            }

            if (country!=null)
            {
                fullAddress.Append(",");
                fullAddress.Append(country);
            }

            return fullAddress.ToString();
        }

        public string GetUnitNumber(string tmpAddress)
        {

            //Loop for unit number
            foreach (string ptrn in ptrns)
            {
                Regex expression = new Regex(ptrn);
                if (expression.IsMatch(tmpAddress))
                {

                    var results = expression.Match(tmpAddress);

                    string foundResult = results.Groups[0].Value;

                    if (ptrns.IndexOf(ptrn) == ptrns.Count - 1 || ptrns.IndexOf(ptrn) == ptrns.Count - 2)
                    {
                        string[] splitedAddress = tmpAddress.Split(' ');
                        foundResult = splitedAddress[0];
                    }

                    return foundResult;
                }
            }

            return "";

        }
    }
}

