using CDK.DataAccess.Models.ddf;
using CDK.ETL.DDF.DdfRawModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDK.ETL.Core.Extenstions
{
    static class UnitAgentPhoneExtensions
    {

        public static void Map(this UnitAgentPhone Phone, PropertyAgentPhone model)
        {

            Phone.UnitAgentId = model.PropertyAgentId;
            Phone.ContactType = model.ContactType;
            Phone.PhoneType = model.PhoneType;
            Phone.PhoneNumber = model.PhoneNumber;

        }

        public static void MapAll(this List<UnitAgentPhone> unitAgentPhones, List<PropertyAgentPhone> models)
        {
            models.ToList().ForEach(model =>
            {
                UnitAgentPhone unitAgentPhone = new UnitAgentPhone();
                unitAgentPhone.Map(model);
                unitAgentPhones.Add(unitAgentPhone);
            });
        }
    }
}

