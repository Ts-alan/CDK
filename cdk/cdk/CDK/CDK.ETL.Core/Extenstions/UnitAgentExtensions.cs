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
    static class UnitAgentExtensions
    {

        public static void Map(this UnitAgent agent, PropertyAgent model)
        {

            agent.Id = model.PropertyAgentId;
            agent.UnitAgentOfficeId = model.PropertyAgentOfficeId;
            agent.DdfAgentId = model.DdfAgentId;
            agent.Name = model.Name;
            agent.Position = model.Position;
            agent.LastUpdate = model.LastUpdate;
            agent.EducationCredentials = model.EducationCredentials;
            agent.PhotoLastUpdated = model.PhotoLastUpdated;
            agent.StreetAddress = model.StreetAddress;
            agent.AddressLine1 = model.AddressLine1;
            agent.Addressline2 = model.Addressline2;
            agent.StreetNumber = model.StreetNumber;
            agent.StreetName = model.StreetName;
            agent.StreetSuffix = model.StreetSuffix;
            agent.City = model.City;
            agent.Province = model.Province;
            agent.PostalCode = model.PostalCode;
            agent.ThumbnailPhotoUri = PhotoUtils.GetAgentThumbnailLogoUri(model.Name);
            agent.LargePhotoUri = PhotoUtils.GetAgentLargeLogoUri(model.Name);
            agent.LastUpdate = DateTime.Now;
        }
    }
}
