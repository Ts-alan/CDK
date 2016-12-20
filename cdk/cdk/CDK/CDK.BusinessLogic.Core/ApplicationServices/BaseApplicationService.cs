using AutoMapper;
using NLog;
using Repository.Pattern.UnitOfWork;
using System;
using System.Data.Entity.Validation;



namespace CDK.BusinessLogic.Core.ApplicationServices
{
    internal abstract class BaseApplicationService : IDisposable
    {
        protected readonly IUnitOfWorkAsync UnitOfWork;

        protected readonly Logger Logger;

        protected readonly IMapper Mapper;

        protected BaseApplicationService(IUnitOfWorkAsync unitOfWork)
        {
            this.Logger = LogManager.GetCurrentClassLogger();
            this.Mapper = AutoMapperConfig.GetMapper();
            this.UnitOfWork = unitOfWork;
        }

        public void Dispose()
        {
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
            this.TryInvokeServiceAction(
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