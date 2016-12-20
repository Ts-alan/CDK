using CDK.DataAccess.Models;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;
using System.Data.Entity;
using System.Linq;
using Repository.Pattern.Ef6;

namespace CDK.BusinessLogic.Core.Extenstions
{
    public static class RepositoryExtentions
    {
        public static void MapPreviousData<TEntity>(this IUnitOfWorkAsync uow, TEntity data) where TEntity : BaseModel, IObjectState
        {
            UnitOfWork test=new UnitOfWork();
           
            var repo = uow.Repository<TEntity>();
            var prevObj = ((IDbSet<TEntity>)repo.Queryable()).AsNoTracking().FirstOrDefault(x => x.Id == data.Id);

            data.Created = prevObj.Created;
            data.CreatedBy = prevObj.CreatedBy;
        }

        public static TEntity FindWithoutTracking<TEntity>(IRepository<TEntity> repo, params object[] keyValues) where TEntity : BaseModel, IObjectState
        {
            return ((IDbSet<TEntity>)((IDbSet<TEntity>)repo.Queryable()).AsNoTracking()).Find(keyValues);
        }
    }
}