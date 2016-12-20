using CDK.BusinessLogic.Core.DTO.CMS;
using System.Collections.Generic;

namespace CDK.BusinessLogic.Core.ApplicationServices.CMS.Interfaces
{
    public interface IEntityCRUDService<TEntity> where TEntity : BaseModel
    {
        IList<TEntity> GetAll();

        void Create(TEntity model);

        TEntity GetById(long id);

        void Update(TEntity model);

        void DeleteById(long id);
    }
}