using CDK.DataAccess.Models.ddf;
using CDK.ETL.Core.SpecialPocos;
using CDK.ETL.DDF.DdfRawModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDK.ETL.Core.Extenstions
{
    static class AddressExtensions
    {

        public static void Map(this BuildingAddress buildingAddress, Property model, AddressResultPoco addressPoco)
        {

            buildingAddress.StreetAddress = addressPoco.StreetAddress;
            buildingAddress.FullAddress = addressPoco.FullAddress;
            buildingAddress.City = addressPoco.City;
            buildingAddress.CountryState = addressPoco.State;
            buildingAddress.PostalCode = addressPoco.PostalCode;
            buildingAddress.Country = "Canada";
            buildingAddress.Lon = addressPoco.Lon;
            buildingAddress.Lat = addressPoco.Lat;
            buildingAddress.AdditionalStreetInfo = "";
            buildingAddress.DdfCommunityName = "";
            buildingAddress.Subdivision = "";

        }
    }
}