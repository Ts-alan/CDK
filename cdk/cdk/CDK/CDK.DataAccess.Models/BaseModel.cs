using Repository.Pattern.Ef6;
using System;

namespace CDK.DataAccess.Models
{
    public class BaseModel : Entity, IBaseModel
    {
        public long Id
        {
            get; set;
        } // Id (Primary key)

        public DateTime LastUpdate
        {
            get; set;
        }  //LastUpdate

        public DateTime Created
        {
            get; set;
        }  //Created

        public string CreatedBy
        {
            get; set;
        }  //CreatedBy

        public string LastUpdateBy
        {
            get; set;
        }
    }
}