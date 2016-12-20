using CDK.DataAccess.Models.ddf;
using CDK.ETL.DDF.DdfRawModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDK.ETL.Core.Extenstions
{
    static class UnitAgentSpecialityExtensions
    {

        public static void Map(this UnitAgentSpeciality speciality, PropertyAgentSpeciality model)
        {
            speciality.UnitAgentId = model.PropertyAgentId;
            speciality.Specialtie = model.Specialtie;
        }

        public static void MapAll(this List<UnitAgentSpeciality> unitAgentSpecialities, List<PropertyAgentSpeciality> models)
        {
            models.ToList().ForEach(model =>
            {
                UnitAgentSpeciality unitAgentSpeciality = new UnitAgentSpeciality();
                unitAgentSpeciality.Map(model);
                unitAgentSpecialities.Add(unitAgentSpeciality);
            });
        }

    }
}
