using CDK.BusinessLogic.Core.DTO.CMS;
using System.Collections.Generic;

namespace CDK.BusinessLogic.Core.ApplicationServices.CMS.Interfaces
{
    public interface ICMSApplicationService
    {
        IEntityCRUDService<T> GetCRUD<T>() where T : BaseModel;

        IDictionary<string, string> GetDevelopmentAmenitiesImagesList();
    }
}