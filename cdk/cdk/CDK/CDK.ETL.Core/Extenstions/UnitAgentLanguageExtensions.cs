using CDK.DataAccess.Models.ddf;
using CDK.ETL.DDF.DdfRawModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDK.ETL.Core.Extenstions
{
    static class UnitAgentLanguageExtensions
    {

        public static void Map(this UnitAgentLanguage language, PropertyAgentLanguage model)
        {

            language.UnitAgentId = model.PropertyAgentId;
            language.Language = model.Language;

        }

        public static void MapAll(this List<UnitAgentLanguage> unitAgentLanguages, List<PropertyAgentLanguage> models)
        {
            models.ToList().ForEach(model =>
            {
                UnitAgentLanguage unitAgentLanguage = new UnitAgentLanguage();
                unitAgentLanguage.Map(model);
                unitAgentLanguages.Add(unitAgentLanguage);
            });
        }
    }
}
