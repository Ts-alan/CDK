using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDK.BusinessLogic.Core.DTO.Client
{
    class ListUnit
    {
        public List<DTO.Client.UnitForGallery> Units
        {
            get; set;
        }
        public int TotalCount
        {
            get; set;
        }
     
    }
}
