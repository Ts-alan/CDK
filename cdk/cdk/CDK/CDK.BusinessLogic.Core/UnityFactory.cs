using CDK.BusinessLogic.Core.ApplicationServices.Client;
using CDK.BusinessLogic.Core.ApplicationServices.Client.Interfaces;
using CDK.BusinessLogic.Core.ApplicationServices.CMS;
using CDK.BusinessLogic.Core.ApplicationServices.CMS.Interfaces;
using CDK.BusinessLogic.Core.ApplicationServices.Stores;
using CDK.BusinessLogic.Core.ApplicationServices.Stores.Interfaces;
using CDK.DataAccess.Repositories;
using Microsoft.Practices.Unity;
using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.UnitOfWork;

namespace CDK.BusinessLogic.Core
{
    public class UnityFactory
    {
        public IUnityContainer Container
        {
            get; set;
        }

        public UnityFactory()
        {
            this.Container = new UnityContainer();

            this.Container.RegisterType<IDataContextAsync, CDKDbContext>(new InjectionConstructor());
            this.Container.RegisterType<IUnitOfWorkAsync, UnitOfWork>();
            this.Container.RegisterType<IBlobManager, BlobManager>();

            this.Container.RegisterType<ICDKRoleStore, RoleStore>();

            this.Container.RegisterType<ICDKUserStore, UserStore>();

            this.Container.RegisterType<ICMSApplicationService, CMSApplicationService>();
            this.Container.RegisterType<IClientSearchService, ClientSearchService>();
            this.Container.RegisterType<IClientMapService, ClientMapService>();             
        }
    }
}