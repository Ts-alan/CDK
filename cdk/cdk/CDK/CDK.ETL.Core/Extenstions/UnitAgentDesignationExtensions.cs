using CDK.DataAccess.Models.ddf;
using CDK.ETL.DDF.DdfRawModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDK.ETL.Core.Extenstions
{
    static class UnitAgentDesignationExtensions
    {

        public static void Map(this UnitAgentDesignation designation, PropertyAgentDesignation model)
        {

            designation.UnitAgentId = model.PropertyAgentId;
            designation.Designation = model.Designation;

        }

        public static void MapAll(this List<UnitAgentDesignation> unitAgentDesignations, List<PropertyAgentDesignation> models)
        {
            models.ToList().ForEach(model =>
            {
                UnitAgentDesignation unitAgentDesignation = new UnitAgentDesignation();
                unitAgentDesignation.Map(model);
                unitAgentDesignations.Add(unitAgentDesignation);
            });
        }
    }
}
