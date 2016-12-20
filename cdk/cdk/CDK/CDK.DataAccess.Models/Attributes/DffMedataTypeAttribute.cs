using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDK.DataAccess.Models.Attributes
{    
    [AttributeUsage(AttributeTargets.Class)]
    public class DffMedataTypeAttribute : Attribute
    {
        public string TypeName;

        public string SubTypeName;

        public bool Skeep;


        public DffMedataTypeAttribute(string subType, string name = "Property", bool skeep = false)
        {
            this.TypeName = name;
            this.SubTypeName = subType;
            this.Skeep = skeep;
        }
    }
}
