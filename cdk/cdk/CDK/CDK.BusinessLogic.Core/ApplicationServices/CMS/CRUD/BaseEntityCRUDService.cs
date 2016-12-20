using CDK.BusinessLogic.Core.ApplicationServices.CMS.Interfaces;
using System;
using System.Collections.Generic;
using CDK.BusinessLogic.Core.DTO.CMS;
using Db = CDK.DataAccess.Models;
using Repository.Pattern.UnitOfWork;
using System.Linq;
using CDK.BusinessLogic.Core.Extenstions;

namespace CDK.BusinessLogic.Core.ApplicationServices.CMS.CRUD
{
    internal class BaseEntityCRUDService<TEntity, TDbEntity> : BaseApplicationService, IEntityCRUDService<TEntity>
        where TEntity : BaseModel
        where TDbEntity : Db.BaseModel
    {
        public BaseEntityCRUDService(IUnitOfWorkAsync unitOfWork) : base(unitOfWork)
        {
        }

        public virtual void Create(TEntity model)
        {
            this.InvokeInUnitOfWorkScope(uow =>
            {
                uow.Repository<TDbEntity>().Insert(this.Mapper.Map<TDbEntity>(model));
                uow.SaveChanges();
            });
        }

        public virtual void DeleteById(long id)
        {
            this.InvokeInUnitOfWorkScope(uow =>
            {
                var repo = uow.Repository<TDbEntity>();
                var model = repo.Find(id);

                if (model != null)
                {
                    repo.Delete(model);
                    uow.SaveChanges();
                }
            });
        }

        public virtual IList<TEntity> GetAll()
        {
            return this.InvokeInUnitOfWorkScope(uow => this.Mapper.Map<IList<TDbEntity>, IList<TEntity>>(uow.Repository<TDbEntity>().Query().Select().ToList()));
        }

        public virtual TEntity GetById(long id)
        {
            return this.InvokeInUnitOfWorkScope(uow =>
            {
                var model = uow.Repository<TDbEntity>().Find(id);

                if (model == null)
                {
                    return null;
                }

                return this.Mapper.Map<TEntity>(model);
            });
        }

        public virtual void Update(TEntity model)
        {
            this.InvokeInUnitOfWorkScope(uow =>
            {
                var repo = uow.Repository<TDbEntity>();

                var md = this.Mapper.Map<TDbEntity>(model);

                uow.MapPreviousData(md);

                repo.Update(md);
                uow.SaveChanges();
            });
        }
    }
}
