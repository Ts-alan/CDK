using CDK.DataAccess.Models.ddf;
using CDK.ETL.DDF.DdfRawModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDK.ETL.Core.Extenstions
{
    static class UnitAgentOfficePhoneExtensions
    {

        public static void Map(this UnitAgentOfficePhone officePhone, PropertyAgentOfficePhone model)
        {

            officePhone.UnitAgentOfficeId = model.PropertyAgentOfficeId;
            officePhone.ContactType = model.ContactType;
            officePhone.PhoneType = model.PhoneType;
            officePhone.PhoneNumber = model.PhoneNumber;

        }

        public static void MapAll(this List<UnitAgentOfficePhone> unitAgentOfficePhones, List<PropertyAgentOfficePhone> models)
        {
            models.ToList().ForEach(model =>
            {
                UnitAgentOfficePhone unitAgentOfficePhone = new UnitAgentOfficePhone();
                unitAgentOfficePhone.Map(model);
                unitAgentOfficePhones.Add(unitAgentOfficePhone);
            });
        }
    }
}
