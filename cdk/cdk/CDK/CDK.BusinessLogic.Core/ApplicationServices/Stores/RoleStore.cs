using CDK.BusinessLogic.Core.ApplicationServices.Stores.Interfaces;
using CDK.DataAccess.Models.cdk;
using Repository.Pattern.Ef6;
using Repository.Pattern.UnitOfWork;
using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NLog;

namespace CDK.BusinessLogic.Core.ApplicationServices.Stores
{
    internal class RoleStore : ICDKRoleStore
    {
        protected readonly IUnitOfWorkAsync UnitOfWork;
        protected readonly Logger Logger;

        public RoleStore(UnitOfWork unitOfWork)
        {
            this.Logger = LogManager.GetCurrentClassLogger();
            this.UnitOfWork = unitOfWork;
        }

        public IQueryable<Role> Roles
        {
            get
            {
                return this.UnitOfWork.Repository<Role>().Queryable();
            }
        }

        public Task CreateAsync(Role role)
        {
            return this.InvokeInUnitOfWorkScope(uow =>
            {
                uow.Repository<Role>().Insert(role);
                uow.SaveChanges();

                return Task.FromResult<object>(null);
            });
        }

        public Task DeleteAsync(Role role)
        {
            return this.InvokeInUnitOfWorkScope(uow =>
            {
                if (role == null)
                {
                    throw new ArgumentNullException(nameof(role));
                }

                var repo = uow.Repository<Role>();
                var model = repo.Find(role.Id);

                repo.Delete(model);
                uow.SaveChanges();

                return Task.FromResult<object>(null);
            });
        }

        public void Dispose()
        {
            this.UnitOfWork.Dispose();
        }

        public Task<Role> FindByIdAsync(long roleId)
        {
            return this.InvokeInUnitOfWorkScope(uow =>
            {
                return Task.FromResult<Role>(uow.Repository<Role>().Find(roleId));
            });
        }

        public Task<Role> FindByNameAsync(string roleName)
        {
            return this.InvokeInUnitOfWorkScope(uow =>
            {
                return Task.FromResult<Role>(uow.Repository<Role>().Query(x => x.Name == roleName).Select().First());
            });
        }

        public Task UpdateAsync(Role role)
        {
            return this.InvokeInUnitOfWorkScope(uow =>
            {
                var model = uow.Repository<Role>().Find(role.Id);

                model.Name = role.Name;
                uow.Repository<Role>().Update(model);

                uow.SaveChanges();

                return Task.FromResult(0);
            });
        }

        protected virtual TResult InvokeInUnitOfWorkScope<TResult>(Func<IUnitOfWorkAsync, TResult> func)
        {
            var result = default(TResult);

            this.TryInvokeServiceActionInUnitOfWorkScope(
                work =>
                {
                    result = func.Invoke(work);
                });

            return result;
        }

        protected virtual void InvokeInUnitOfWorkScope(Action<IUnitOfWorkAsync> action)
        {
            this.TryInvokeServiceActionInUnitOfWorkScope(action.Invoke);
        }

        private void TryInvokeServiceActionInUnitOfWorkScope(Action<IUnitOfWorkAsync> action)
        {
            this.`TryInvokeServiceAction(
                () =>
                {
                    action.Invoke(this.UnitOfWork);
                });
        }

        private void TryInvokeServiceAction(Action action)
        {
            try
            {
                action.Invoke();
            }
            /*catch (InvalidOperationException exception)
            {
            }   */
            catch (DbEntityValidationException ex)
            {
                Logger.Error(ex, "User");
                throw ex;
            }
            catch (Exception exception)
            {
                Logger.Error(exception, "User");
                throw new InvalidOperationException("cannot invoke service action", exception);
            }
        }
    }
}