using System;

namespace CDK.BusinessLogic.Core.DTO.CMS
{
    public class BaseModel
    {
        public long Id
        {
            get; set;
        }

        public DateTime LastUpdate
        {
            get; set;
        }

        public DateTime Created
        {
            get; set;
        }

        public string CreatedBy
        {
            get; set;
        }

        public string LastUpdateBy
        {
            get; set;
        }
    }
}