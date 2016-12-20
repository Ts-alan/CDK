using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDK.BusinessLogic.Core.DTO.Client
{
    public class Photo
    {
        public string ThumbnailUri
        {
            get; set;
        }

        public string LargeUri
        {
            get; set;
        }

        public string SmallUri
        {
            get; set;
        }

        public string AltText
        {
            get; set;
        }
    }
}
