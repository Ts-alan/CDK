using CDK.DataAccess.Models.ddf;
using CDK.DataAccess.Repositories;
using CDK.ETL.DDF.DdfRawModel;
using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDK.ETL.Core.Extenstions;
using CDK.ETL.Core.Managers;
using System.Configuration;
using CDK.ETL.DDF;
using System.IO;
using CDK.ETL.Core.Utils;

namespace CDK.ETL.Core.Services
{
    public class OfficeCRUDService
    {

        BlobManager blobManager;
        DdfCoreManager ddfCoreManager;

        public OfficeCRUDService(RestSession session)
        {
            this.blobManager = new BlobManager(ConfigurationManager.AppSettings["storageString"], ConfigurationManager.AppSettings["storageOfficePhotoContainerName"]);
            this.ddfCoreManager = new DdfCoreManager(session);
        }

        public List<UnitAgentOffice> GetAll()
        {
            using (var context = new CDKDbContext())
            using (var uow = new UnitOfWork(context))
            {
                return uow.Repository<UnitAgentOffice>()
                .Query()
                .Select()
                .ToList();
            }
        }

        public UnitAgentOffice GetById(long id)
        {
            using (var context = new CDKDbContext())
            using (var uow = new UnitOfWork(context))
            {
                return uow.Repository<UnitAgentOffice>()
                .Query(x => x.Id == id)
                .Select()
                .FirstOrDefault();
            }
        }

        public void CreateOrUpdate(PropertyAgentOffice model)
        {

            try
            {

                using (var context = new CDKDbContext())
                using (var uow = new UnitOfWork(context))
                {

                    var dbModel = uow.Repository<UnitAgentOffice>()
                    .Query(x => x.Id == model.PropertyAgentOfficeId)
                    .Include(o => o.UnitAgentOfficePhones)
                    .Include(o => o.UnitAgentOfficeWebsites)
                    .Select()
                    .FirstOrDefault();

                    if (dbModel != null)
                    {

                        //Remove phones
                        foreach (var item in dbModel.UnitAgentOfficePhones.ToList())
                        {
                            uow.Repository<UnitAgentOfficePhone>().Delete(item);
                        }

                        //Remove website
                        foreach (var item in dbModel.UnitAgentOfficeWebsites.ToList())
                        {
                            uow.Repository<UnitAgentOfficeWebsite>().Delete(item);
                        }

                        dbModel.Map(model);
                        uow.Repository<UnitAgentOffice>().Update(dbModel);

                    }
                    else
                    {
                        dbModel = new UnitAgentOffice();
                        dbModel.Map(model);
                        uow.Repository<UnitAgentOffice>().Insert(dbModel);
                    }

                    //Insert phone
                    if (model.PropertyAgentOfficeWebsite != null)
                    {
                        List<UnitAgentOfficePhone> unitAgentOfficePhones = new List<UnitAgentOfficePhone>();
                        unitAgentOfficePhones.MapAll(model.PropertyAgentOfficePhone.ToList());

                        unitAgentOfficePhones.ForEach(x => {
                            uow.Repository<UnitAgentOfficePhone>().Insert(x);
                        });
                        dbModel.UnitAgentOfficePhones = unitAgentOfficePhones;
                    }

                    //Insert website
                    if (model.PropertyAgentOfficeWebsite != null)
                    {
                        List<UnitAgentOfficeWebsite> unitAgentOfficeWebsites = new List<UnitAgentOfficeWebsite>();
                        unitAgentOfficeWebsites.MapAll(model.PropertyAgentOfficeWebsite.ToList());

                        unitAgentOfficeWebsites.ForEach(x => {
                            uow.Repository<UnitAgentOfficeWebsite>().Insert(x);
                        });
                        dbModel.UnitAgentOfficeWebsites = unitAgentOfficeWebsites;
                    }

                    uow.SaveChanges();

                    //InsertUnitAgentOfficePhotoIntoStorage(dbModel.DdfUnitAgentOfficeId, dbModel.LogoUri);

                }

            }
            catch (Exception e)
            {
                throw new Exception(String.Format("Can't create or update <{0}>", typeof(UnitAgentOffice)), e);
            }
        }

        public void DeleteById(long id)
        {
            using (var context = new CDKDbContext())
            using (var uow = new UnitOfWork(context))
            {
                var repo = uow.Repository<UnitAgentOffice>();
                var UnitAgentOffice = repo.Find(id);

                if (UnitAgentOffice != null)
                {
                    repo.Delete(UnitAgentOffice);
                    uow.SaveChanges();
                }
            }
        }

        public bool InsertUnitAgentOfficePhotoIntoStorage(string officeId, string logoUri)
        {

            try
            {
                MemoryStream ms = ddfCoreManager.GetObject("Office", officeId, PhotoUtils.ThumbNailPhotoAlias);
                blobManager.UploadFromStream(ms, logoUri);
            }
            catch (Exception e)
            {
                Console.WriteLine(">>> Error uploading image on azure storage", e);
                throw new Exception("Error uploading image on azure storage", e);
            }

            return true;

        }

    }
}
