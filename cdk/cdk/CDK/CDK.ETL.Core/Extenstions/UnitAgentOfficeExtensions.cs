using CDK.DataAccess.Models.ddf;
using CDK.ETL.Core.Utils;
using CDK.ETL.DDF.DdfRawModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDK.ETL.Core.Extenstions
{
    static class UnitAgentOfficeExtensions
    {

        public static void Map(this UnitAgentOffice office, PropertyAgentOffice model)
        {

            office.Id = model.PropertyAgentOfficeId;
            office.DdfUnitAgentOfficeId = model.DdfPropertyAgentOfficeId;
            office.Name = model.Name;
            office.StreetAddress = model.StreetAddress;
            office.AddressLine1 = model.AddressLine1;
            office.City = model.City;
            office.PostalCode = model.PostalCode;
            office.Country = model.Country;
            office.Franchisor = model.Franchisor;
            office.LogoLastUpdated = model.LogoLastUpdated;
            office.OrganizationType = model.OrganizationType;
            office.Designation = model.Designation;
            office.LogoUri = PhotoUtils.GetOfficeThumbnailLogoUri(model.Name);
            office.LastUpdate = DateTime.Now;

        }
    }
}
