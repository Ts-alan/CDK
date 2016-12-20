using CDK.DataAccess.Models.ddf;
using CDK.ETL.DDF.DdfRawModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDK.ETL.Core.Extenstions
{
    static class UnitAgentWebsiteExtensions
    {

        public static void Map(this UnitAgentWebsite agentWebsite, PropertyAgentWebsite model)
        {

            agentWebsite.UnitAgentId = model.PropertyAgentId;
            agentWebsite.ContactType = model.ContactType;
            agentWebsite.WebsiteType = model.WebsiteType;
            agentWebsite.WebsiteUrl = model.WebsiteUrl;

        }

        public static void MapAll(this List<UnitAgentWebsite> unitAgentWebsites, List<PropertyAgentWebsite> models)
        {
            models.ToList().ForEach(model =>
            {
                UnitAgentWebsite unitAgentWebsite = new UnitAgentWebsite();
                unitAgentWebsite.Map(model);
                unitAgentWebsites.Add(unitAgentWebsite);
            });
        }

    }
}
