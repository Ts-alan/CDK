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
using System.IO;
using CDK.ETL.DDF;
using CDK.ETL.Core.Utils;

namespace CDK.ETL.Core.Services
{
    public class AgentCRUDService
    {

        BlobManager blobManager;
        DdfCoreManager ddfCoreManager;

        public AgentCRUDService(RestSession session)
        {
            this.blobManager = new BlobManager(ConfigurationManager.AppSettings["storageString"], ConfigurationManager.AppSettings["storageAgentPhotoContainerName"]);
            this.ddfCoreManager = new DdfCoreManager(session);
        }

        public List<UnitAgent> GetAll()
        {
            using (var context = new CDKDbContext())
            using (var uow = new UnitOfWork(context))
            {
                return uow.Repository<UnitAgent>()
                .Query()
                .Select()
                .ToList();
            }
        }

        public UnitAgent GetById(long id)
        {
            using (var context = new CDKDbContext())
            using (var uow = new UnitOfWork(context))
            {
                return uow.Repository<UnitAgent>()
                .Query(x => x.Id == id)
                .Select()
                .FirstOrDefault();
            }
        }

        public void CreateOrUpdate(PropertyAgent model)
        {

            try
            {

                using (var context = new CDKDbContext())
                using (var uow = new UnitOfWork(context))
                {

                    var dbModel = uow.Repository<UnitAgent>()
                    .Query(x => x.Id == model.PropertyAgentId)
                    .Include(o => o.UnitAgentPhones)
                    .Include(o => o.UnitAgentWebsites)
                    .Include(o => o.UnitAgentLanguages)
                    .Include(o => o.UnitAgentSpecialities)
                    .Include(o => o.UnitAgentDesignations)
                    .Select()
                    .FirstOrDefault();

                    if (dbModel != null)
                    {

                        //Remove phones
                        dbModel.UnitAgentPhones.ToList().ForEach(x =>
                        {
                            uow.Repository<UnitAgentPhone>().Delete(x);
                        });

                        //Remove website
                        dbModel.UnitAgentWebsites.ToList().ForEach(x =>
                        {
                            uow.Repository<UnitAgentWebsite>().Delete(x);
                        });

                        //Remove language
                        dbModel.UnitAgentLanguages.ToList().ForEach(x =>
                        {
                            uow.Repository<UnitAgentLanguage>().Delete(x);
                        });

                        //Remove designation
                        dbModel.UnitAgentDesignations.ToList().ForEach(x =>
                        {
                            uow.Repository<UnitAgentDesignation>().Delete(x);
                        });

                        //Remove speciality
                        dbModel.UnitAgentSpecialities.ToList().ForEach(x =>
                        {
                            uow.Repository<UnitAgentSpeciality>().Delete(x);
                        });

                        //Map and update
                        dbModel.Map(model);
                        uow.Repository<UnitAgent>().Update(dbModel);

                    }
                    else
                    {
                        //Map and insert
                        dbModel = new UnitAgent();
                        dbModel.Map(model);
                        uow.Repository<UnitAgent>().Insert(dbModel);
                    }

                    //Insert phone
                    if (model.PropertyAgentPhone != null)
                    {
                        List<UnitAgentPhone> unitAgentPhones = new List<UnitAgentPhone>();
                        unitAgentPhones.MapAll(model.PropertyAgentPhone.ToList());

                        unitAgentPhones.ForEach(x => {
                            uow.Repository<UnitAgentPhone>().Insert(x);
                        });
                        dbModel.UnitAgentPhones = unitAgentPhones;
                    }


                    //Insert website
                    if (model.PropertyAgentWebsite != null)
                    {
                        List<UnitAgentWebsite> unitAgentWebsites = new List<UnitAgentWebsite>();
                        unitAgentWebsites.MapAll(model.PropertyAgentWebsite.ToList());

                        unitAgentWebsites.ForEach(x => {
                            uow.Repository<UnitAgentWebsite>().Insert(x);
                        });
                        dbModel.UnitAgentWebsites = unitAgentWebsites;
                    }

                    //Insert language
                    if (model.PropertyAgentLanguage != null)
                    {
                        List<UnitAgentLanguage> unitAgentLanguages = new List<UnitAgentLanguage>();
                        unitAgentLanguages.MapAll(model.PropertyAgentLanguage.ToList());

                        unitAgentLanguages.ForEach(x => {
                            uow.Repository<UnitAgentLanguage>().Insert(x);
                        });
                        dbModel.UnitAgentLanguages = unitAgentLanguages;
                    }

                    //Insert Speciality
                    if (model.PropertyAgentSpeciality != null)
                    {
                        List<UnitAgentSpeciality> unitAgentSpecialities = new List<UnitAgentSpeciality>();
                        unitAgentSpecialities.MapAll(model.PropertyAgentSpeciality.ToList());

                        unitAgentSpecialities.ForEach(x => {
                            uow.Repository<UnitAgentSpeciality>().Insert(x);
                        });
                        dbModel.UnitAgentSpecialities = unitAgentSpecialities;
                    }

                    //Insert Designation
                    if (model.PropertyAgentDesignation != null)
                    {
                        List<UnitAgentDesignation> unitAgentDesignations = new List<UnitAgentDesignation>();
                        unitAgentDesignations.MapAll(model.PropertyAgentDesignation.ToList());

                        unitAgentDesignations.ForEach(x => {
                            uow.Repository<UnitAgentDesignation>().Insert(x);
                        });
                        dbModel.UnitAgentDesignations = unitAgentDesignations;
                    }

                    var dbModelOffice = uow.Repository<UnitAgentOffice>()
                                        .Query(x => x.Id == model.PropertyAgentOfficeId)
                                        .Select()
                                        .FirstOrDefault();

                    //Bind the office to the agent
                    if (dbModelOffice != null)
                    {
                        dbModel.UnitAgentOfficeId = dbModelOffice.Id;
                    }

                    /*
                    InsertUnitAgentPhotoIntoStorage(dbModel.DdfAgentId, dbModel.ThumbnailPhotoUri, PhotoUtils.ThumbNailPhotoAlias);
                    InsertUnitAgentPhotoIntoStorage(dbModel.DdfAgentId, dbModel.LargePhotoUri, PhotoUtils.LargePhotoAlias);
                    */

                    uow.SaveChanges();

                }

            }
            catch (Exception e)
            {

                throw new Exception(String.Format("Can't create or update <{0}>", typeof(UnitAgent)), e);
            }

 
        }

        public bool InsertUnitAgentPhotoIntoStorage(string agentId, string logoUri, string photoType)
        {

            try
            {
                MemoryStream ms = ddfCoreManager.GetObject("Agent", agentId, photoType);
                blobManager.UploadFromStream(ms, logoUri);
            }
            catch (Exception e)
            {
                Console.WriteLine(">>> Error uploading image on azure storage", e);
            }

            return true;

        }

        public void DeleteById(long id)
        {
            using (var context = new CDKDbContext())
            using (var uow = new UnitOfWork(context))
            {
                var repo = uow.Repository<UnitAgent>();
                var UnitAgent = repo.Find(id);

                if (UnitAgent != null)
                {
                    repo.Delete(UnitAgent);
                    uow.SaveChanges();
                }
            }
        }
    }
}
