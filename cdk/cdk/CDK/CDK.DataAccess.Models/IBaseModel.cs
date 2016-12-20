using Repository.Pattern.Infrastructure;
using System;

namespace CDK.DataAccess.Models
{
    public interface IBaseModel : IObjectState
    {
        long Id
        {
            get; set;
        } // Id (Primary key)

        DateTime LastUpdate
        {
            get; set;
        }  //LastUpdate

        DateTime Created
        {
            get; set;
        }  //Created

        string CreatedBy
        {
            get; set;
        }  //CreatedBy

        string LastUpdateBy
        {
            get; set;
        }
    }
}