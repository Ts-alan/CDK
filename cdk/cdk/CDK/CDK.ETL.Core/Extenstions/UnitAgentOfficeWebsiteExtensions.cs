using CDK.DataAccess.Models.ddf;
using CDK.ETL.DDF.DdfRawModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDK.ETL.Core.Extenstions
{
    static class UnitAgentOfficeWebsiteExtensions
    {

        public static void Map(this UnitAgentOfficeWebsite officeWebsite, PropertyAgentOfficeWebsite model)
        {

            officeWebsite.UnitAgentOfficeId = model.PropertyAgentOfficeId;
            officeWebsite.ContactType = model.ContactType;
            officeWebsite.WebsiteType = model.WebsiteType;
            officeWebsite.WebsiteUrl = model.WebsiteUrl;

        }

        public static void MapAll(this List<UnitAgentOfficeWebsite> unitAgentOfficeWebsites, List<PropertyAgentOfficeWebsite> models)
        {
            models.ToList().ForEach(model =>
            {
                UnitAgentOfficeWebsite unitAgentOfficeWebsite = new UnitAgentOfficeWebsite();
                unitAgentOfficeWebsite.Map(model);
                unitAgentOfficeWebsites.Add(unitAgentOfficeWebsite);
            });
        }
    }
}
