using CDK.DataAccess.Models;
using CDK.DataAccess.Models.Attributes;
using CDK.DataAccess.Models.ddf;
using CDK.DataAccess.Repositories;
using CDK.ETL.Core.Extenstions;
using CDK.ETL.Core.Managers;
using CDK.ETL.DDF;
using CDK.ETL.DDF.DdfRawModel;
using EntityFramework.Utilities;
using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace CDK.ETL.Core
{
    internal class Injector
    {

        private static DdfCoreManager ddfCoreManager = null;
        private static DdfUnitManager ddfUnitManager = null;
        private static DdfOfficeManager ddfOfficeManager = null;
        private static DdfAgentManager ddfAgentManager = null;

        private static void Main(string[] args)
        {
            var watch = Stopwatch.StartNew();
            Console.WriteLine(">>> STARTING INJECTOR PROCESS");

            ddfCoreManager = new DdfCoreManager();

            try
            {

                //LOGIN ATTEMPT
                RestSession session = ddfCoreManager.LoginTransaction();
                while (session==null)
                {
                    session = ddfCoreManager.LoginTransaction();
                    System.Threading.Thread.Sleep(10000);
                }

                if (session!=null)
                {

                    ddfUnitManager = new DdfUnitManager(session);
                    ddfOfficeManager = new DdfOfficeManager(session);
                    ddfAgentManager = new DdfAgentManager(session);
                    DdfMetadataManager.Instance.SetDdfCoreManager(session);

                    //Remove all properties that are not in the master list
                    if (RemoveDeletedUnits())
                    {
                        //Add or update properties with the last updatedDateTime
                        if (ProcessLastUpdatesFromDdf())
                        {
                            InsertAuditDdfRequest();
                        }
                    }

                    //LOGOUT
                    ddfCoreManager.LogoutTransaction();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(">>> INJECTOR PROCESS DID NOT END PROPERLY: " + e);
            }

            watch.Stop();
            Console.WriteLine(">>> ENDING INJECTOR PROCESS ({0} ms)", watch.ElapsedMilliseconds);

        }

        private static bool RemoveDeletedUnits()
        {
            try
            {
                var watch = Stopwatch.StartNew();
                Console.WriteLine(">>> STARTING REMOVING DELETED PROCESS");
                //Ddf propertyIds
                Dictionary<string, string> masterList = ddfCoreManager.GetPropertyMasterList();
                ddfUnitManager.RemoveDeletedUnits(masterList);
                watch.Stop();
                Console.WriteLine(">>> ENDING REMOVING DELETED PROCESS ({0} ms)", watch.ElapsedMilliseconds);
                return true;

            }
            catch (Exception e)
            {
                string errMessage = string.Format(">>> Can't remove units - {0}", e);
                Console.WriteLine(errMessage);
                return false;
            }
        }

        private static bool ProcessLastUpdatesFromDdf()
        {
            var watch = Stopwatch.StartNew();
            Console.WriteLine(">>> STARTING UPDATING PROCESS");

            try
            {
                DateTime? ddfLastUpdate = null;
                using (var context = new CDKDbContext())
                {
                    List<DateTime> ddfLastUpdates = context.Database.SqlQuery<DateTime>("SELECT DdfLastUpdate FROM ddf.AuditDdfRequest order by DdfLastUpdate desc").ToList();
                    if (ddfLastUpdates.Count > 0)
                    {
                        ddfLastUpdate = ddfLastUpdates.First();
                    }
                }
                
                if (ddfLastUpdate != null)
                {
                    ProcessMetadata();
                    ProcessOffices(ddfLastUpdate);
                    ProcessAgents(ddfLastUpdate);
                    ProcessUnits(ddfLastUpdate);
                }
                else
                {
                    //ProcessMetadata();
                    //BootDatabaseWithAllOffices();
                    //BootDatabaseWithAllAgents();
                    BootDatabaseWithAllUnits();
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            watch.Stop();
            Console.WriteLine(">>> ENDING UPDATING PROCESS ({0} ms)", watch.ElapsedMilliseconds);

            return true;
        }

        private static void InsertAuditDdfRequest()
        {
            using (var context = new CDKDbContext())
            using (var uow = new UnitOfWork(context))
            {
                //Perform create operation
                uow.Repository<AuditDdfRequest>().Insert(new AuditDdfRequest()
                {
                    //AuditDdfRequest
                    Status = "COMPLETED",
                    Xml = null,
                    DdfLastUpdate = DateTime.Now
                });

                //Execute Inser, Update & Delete queries in the database
                uow.SaveChanges();
            }
        }

        private static bool ProcessOffices(DateTime? ddfLastUpdate)
        {
            var watch = Stopwatch.StartNew();
            Console.WriteLine(">>> STARTING UPDATING OFFICES");

            List<CDK.ETL.DDF.Office.RETS> retsOfficeList = ddfCoreManager.GetOfficesFromDdf(ddfLastUpdate);

            try
            {
                ddfOfficeManager.CreateUpdateAgentOffice(retsOfficeList);
            }
            catch (Exception e)
            {
                string errMessage = ">>> Terminating ProcessOffices du to unrecoverable error!";
                Console.WriteLine(errMessage, e.Message);
                throw new Exception(e.Message, e);
            }
            finally
            {
                watch.Stop();
                Console.WriteLine(">>> ENDING UPDATING OFFICES ({0} ms)", watch.ElapsedMilliseconds);
            }

            return true;
        }

        private static bool ProcessAgents(DateTime? ddfLastUpdate)
        {
            var watch = Stopwatch.StartNew();
            Console.WriteLine(">>> STARTING UPDATING AGENTS");

            List<CDK.ETL.DDF.Agent.RETS> retsAgentList = ddfCoreManager.GetAgentsFromDdf(ddfLastUpdate);

            ddfAgentManager.CreateUpdateAgent(retsAgentList);

            watch.Stop();
            Console.WriteLine(">>> ENDING UPDATING AGENTS ({0} ms)", watch.ElapsedMilliseconds);

            return true;
        }

        private static bool ProcessUnits(DateTime? ddfLastUpdate)
        {
            var watch = Stopwatch.StartNew();
            Console.WriteLine(">>> STARTING UPDATING UNITS");

            List<Unit> units = new List<Unit>();

            List<CDK.ETL.DDF.Property.RETS> retsPropertyList = ddfCoreManager.GetPropertiesFromDdf(ddfLastUpdate);

            ddfUnitManager.CreateUpdateUnits(retsPropertyList);
            
            watch.Stop();
            Console.WriteLine(">>> ENDING UPDATING PROPERTIES ({0} ms)", watch.ElapsedMilliseconds);

            return true;
        }

        private static bool ProcessMetadata()
        {
            var watch = Stopwatch.StartNew();
            Console.WriteLine(">>> STARTING INJECTOR PROCESS");

            try
            {

                DdfMetadataManager.Instance.CreateUpdateAllMetadata();

                watch.Stop();
                Console.WriteLine(">>> ENDING INJECTOR PROCESS ({0} ms)", watch.ElapsedMilliseconds);

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(">>> INJECTOR PROCESS DID NOT END PROPERLY: " + e);
                return false;
            }
        }

        private static bool BootDatabaseWithAllUnits()
        {
            var watch = Stopwatch.StartNew();
            Console.WriteLine(">>> STARTING BOOTING UNITS PROCESS");

            try
            {

                List<string> dbPropertyIdsString = new List<string>();

                //Ddf propertyIds
                Dictionary<string, string> masterList = ddfCoreManager.GetPropertyMasterList();

                List<string> ddfPropertyIds = ddfUnitManager.GetOutterUnits(masterList);

                List<string> propertyRequestedIds = new List<string>();
                string tmpRequestedId = "";

                int ctr = 1;
                foreach (var keyValue in ddfPropertyIds)
                {
                    if (ctr % 10 == 0)
                    {
                        tmpRequestedId = tmpRequestedId + keyValue.ToString();
                        propertyRequestedIds.Add(tmpRequestedId);
                        ctr = 1;
                        tmpRequestedId = "";
                    }

                    tmpRequestedId = tmpRequestedId + keyValue.ToString() + ",";
                    ctr++;
                }

                if (tmpRequestedId.Length > 0)
                {
                    tmpRequestedId = tmpRequestedId.Remove(tmpRequestedId.Length - 1);
                    propertyRequestedIds.Add(tmpRequestedId);
                }

                foreach (string ids in propertyRequestedIds)
                {

                    string tmpIdParam = "(ID=" + ids + ")";

                    List<Property> properties = new List<Property>();
                    List<CDK.ETL.DDF.Property.RETS> retsList = ddfCoreManager.GetRequestedProperties("Property", "Property", "DMQL2", tmpIdParam, 1, "None", 1, "en-CA", "STANDARD-XML");

                    ddfUnitManager.CreateUpdateUnits(retsList);

                }
            }
            catch (Exception e)
            {
                string errMessage = ">>> Terminating Boot Database with all units du to unrecoverable error!";
                Console.WriteLine(errMessage, e.Message);
                throw new Exception(e.Message, e);
            }
            finally
            {
                watch.Stop();
                Console.WriteLine(">>> ENDING BOOTING UNITS PROCESS ({0} ms)", watch.ElapsedMilliseconds);
            }

            return true;
        }

        private static bool BootDatabaseWithAllOffices()
        {
            var watch = Stopwatch.StartNew();
            Console.WriteLine(">>> STARTING BOOTING OFFICES PROCESS");

            try
            {

                List<string> dbOfficeIdsString = new List<string>();

                //Ddf OfficeIds
                Dictionary<string, string> masterList = ddfCoreManager.GetOfficeMasterList();
                List<string> OfficeIds = new List<string>(masterList.Keys);

                List<string> OfficeRequestedIds = new List<string>();
                string tmpRequestedId = "";

                int ctr = 1;
                foreach (var keyValue in OfficeIds)
                {
                    if (ctr % 10 == 0)
                    {
                        tmpRequestedId = tmpRequestedId + keyValue.ToString();
                        OfficeRequestedIds.Add(tmpRequestedId);
                        ctr = 1;
                        tmpRequestedId = "";
                    }

                    tmpRequestedId = tmpRequestedId + keyValue.ToString() + ",";
                    ctr++;
                }

                if (tmpRequestedId.Length > 0)
                {
                    tmpRequestedId = tmpRequestedId.Remove(tmpRequestedId.Length - 1);
                    OfficeRequestedIds.Add(tmpRequestedId);
                }

                foreach (string ids in OfficeRequestedIds)
                {
                    string tmpIdParam = "(ID=" + ids + ")";

                    List<PropertyAgentOffice> offices = new List<PropertyAgentOffice>();
                    List<CDK.ETL.DDF.Office.RETS> retsList = ddfCoreManager.GetRequestedOffice("Office", "Office", "DMQL2", tmpIdParam, 1, "None", 1, "en-CA", "STANDARD-XML");

                    ddfOfficeManager.CreateUpdateAgentOffice(retsList);
                }
            }
            catch (Exception e)
            {
                string errMessage = ">>> Terminating Boot Database With All Office du to unrecoverable error!";
                Console.WriteLine(errMessage, e.Message);
                throw new Exception(e.Message, e);
            }
            finally
            {
                watch.Stop();
                Console.WriteLine(">>> ENDING BOOTING OFFICES PROCESS ({0} ms)", watch.ElapsedMilliseconds);
            }

            return true;
        }

        private static bool BootDatabaseWithAllAgents()
        {
            try
            {
                var watch = Stopwatch.StartNew();
                Console.WriteLine(">>> STARTING BOOTING AGENTS PROCESS");

                List<string> dbAgentIdsString = new List<string>();

                //Ddf propertyIds
                Dictionary<string, string> masterList = ddfCoreManager.GetAgentMasterList();
                List<string> ddfAgentIds = new List<string>(masterList.Keys);

                List<string> agentRequestedIds = new List<string>();
                string tmpRequestedId = "";

                int ctr = 1;
                foreach (var keyValue in ddfAgentIds)
                {
                    if (ctr % 10 == 0)
                    {
                        tmpRequestedId = tmpRequestedId + keyValue.ToString();
                        agentRequestedIds.Add(tmpRequestedId);
                        ctr = 1;
                        tmpRequestedId = "";
                    }

                    tmpRequestedId = tmpRequestedId + keyValue.ToString() + ",";
                    ctr++;
                }

                if (tmpRequestedId.Length > 0)
                {
                    tmpRequestedId = tmpRequestedId.Remove(tmpRequestedId.Length - 1);
                    agentRequestedIds.Add(tmpRequestedId);
                }

                foreach (string ids in agentRequestedIds)
                {
                    string tmpIdParam = "(ID=" + ids + ")";

                    List<PropertyAgent> agents = new List<PropertyAgent>();
                    List<CDK.ETL.DDF.Agent.RETS> retsList = ddfCoreManager.GetRequestedAgent("Agent", "Agent", "DMQL2", tmpIdParam, 1, "None", 1, "en-CA", "STANDARD-XML");

                    ddfAgentManager.CreateUpdateAgent(retsList);
                }

                watch.Stop();
                Console.WriteLine(">>> ENDING BOOTING OFFICES PROCESS ({0} ms)", watch.ElapsedMilliseconds);
            }
            catch (Exception e)
            {
                string errMessage = ">>> Terminating Boot Database With All Agent du to unrecoverable error!";
                Console.WriteLine(errMessage, e.Message);
                throw new Exception(e.Message, e);
            }

            return true;
        }
    }
}