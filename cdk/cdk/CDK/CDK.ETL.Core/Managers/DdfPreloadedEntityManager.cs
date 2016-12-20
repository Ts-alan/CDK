using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.Infrastructure;
using CDK.DataAccess.Models.ddf;
using CDK.DataAccess.Repositories;

namespace CDK.ETL.Core.Managers
{
    class DdfPreloadedEntityManager
    {

        private static DdfPreloadedEntityManager instance;

        public static DdfPreloadedEntityManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DdfPreloadedEntityManager();
                }
                return instance;
            }
        }

        private DdfPreloadedEntityManager() { }

        List<BuildingAddress> addresses = new List<BuildingAddress>();

        public List<BuildingAddress> GetAddresses()
        {
            if (addresses == null)
            {
                using (var context = new CDKDbContext())
                {
                    addresses = context.BuildingAddresses.ToList();
                    foreach (var item in addresses)
                        ((IObjectContextAdapter)context).ObjectContext.Detach(item);
                }
            }
            return addresses;
        }
    }
}
