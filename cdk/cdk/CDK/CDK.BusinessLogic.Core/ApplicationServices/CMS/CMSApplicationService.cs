using CDK.BusinessLogic.Core.ApplicationServices.CMS.Interfaces;
using CDK.BusinessLogic.Core.DTO.CMS;
using CDK.BusinessLogic.Core.Extenstions;
using Repository.Pattern.UnitOfWork;
using System.Collections.Generic;
using System.Linq;
using Db = CDK.DataAccess.Models.cdk;
using System;
using CDK.BusinessLogic.Core.ApplicationServices.CMS.CRUD;
using System.Configuration;
using CDK.BusinessLogic.Core.Configuration;

namespace CDK.BusinessLogic.Core.ApplicationServices.CMS
{
    internal class CMSApplicationService : BaseApplicationService, ICMSApplicationService
    {
        private readonly IBlobManager BlobManager;

        public CMSApplicationService(IUnitOfWorkAsync unitOfWork, IBlobManager blobManager) : base(unitOfWork)
        {
            this.BlobManager = blobManager;
        }        

        public IDictionary<string, string> GetDevelopmentAmenitiesImagesList()
        {
            var result = new Dictionary<string, string>();
            var section = (DevelopmentAmenitiesConfigHelper)ConfigurationManager.GetSection("DevelopmentAmenities");

            if (section != null)
            {
                foreach (DevelopmentAmenitiesElement element in section.Keys)
                {
                    result.Add(element.Url, element.Name);
                }
            }

            return result;
        }

        public IEntityCRUDService<T> GetCRUD<T>() where T : BaseModel
        {
            if (typeof(T) == typeof(Developer))
            {
                return (IEntityCRUDService<T>)(new BaseEntityCRUDService<Developer, Db.Developer>(this.UnitOfWork));
            }

            if (typeof(T) == typeof(MetroArea))
            {
                return (IEntityCRUDService<T>)(new BaseEntityCRUDService<MetroArea, Db.MetroArea>(this.UnitOfWork));
            }

            if (typeof(T) == typeof(Development))
            {
                return (IEntityCRUDService<T>)(new DevelopmentCRUDService(this.UnitOfWork, this.BlobManager));
            }

            if (typeof(T) == typeof(DevelopmentAddress))
            {
                return (IEntityCRUDService<T>)(new BaseEntityCRUDService<DevelopmentAddress, Db.DevelopmentAddress>(this.UnitOfWork));
            }

            if (typeof(T) == typeof(NeighborhoodArea))
            {
                return (IEntityCRUDService<T>)(new NeighborhoodAreaCRUDService(this.UnitOfWork));
            }

            if (typeof(T) == typeof(NeighborhoodGuide))
            {
                return (IEntityCRUDService<T>)(new NeighborhoodGuideCRUDService(this.UnitOfWork, this.BlobManager));
            }

            if (typeof(T) == typeof(DevelopmentAmenities))
            {
                return (IEntityCRUDService<T>)(new BaseEntityCRUDService<DevelopmentAmenities, Db.DevelopmentAmenities>(this.UnitOfWork));
            }

            throw new InvalidOperationException();
        }
    }
}