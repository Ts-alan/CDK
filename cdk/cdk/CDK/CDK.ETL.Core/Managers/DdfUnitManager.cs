using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using CDK.ETL.DDF.Property;
using System.IO;
using CDK.DataAccess.Models.ddf;
using CDK.ETL.DDF.DdfRawModel;
using CDK.DataAccess.Repositories;
using CDK.ETL.DDF;
using CDK.ETL.Core.Services;
using System.Diagnostics;

namespace CDK.ETL.Core.Managers
{
    public class DdfUnitManager
    {

        UnitCRUDService unitCRUDService;

        public DdfUnitManager(RestSession session)
        {
            unitCRUDService = new UnitCRUDService(session);
        }

        public void CreateUpdateUnits(List<RETS> retsList)
        {

            int countInserted = 0;
            int countBadAddress = 0;
            int countNoNh = 0;
            int countError = 0;

            foreach (var rets in retsList)
            {
                if (rets.RETSResponse != null && rets.RETSResponse.PropertyDetails != null)
                {
                    foreach (var propertyDetail in rets.RETSResponse.PropertyDetails)
                    {
                        try
                        {
                            Property property = DdfPropertyManager.getPropertyGrap(propertyDetail);
                            string reason = unitCRUDService.CreateOrUpdate(property);

                            if (reason == UnitCRUDService._Success)
                            {
                                countInserted++;
                            }
                            else if (reason == UnitCRUDService._NoNh)
                            {
                                countNoNh++;
                            }
                            else if (reason == UnitCRUDService._BadAddress)
                            {
                                countBadAddress++;
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(string.Format(">>> Can't insert unit with ddfId: {0} - {1}", propertyDetail.ID, e));
                            countError++;
                        }
                    }
                }
            }

            Console.WriteLine(string.Format(">>> Inserted {0}, No neighborhood {1}, Bad Adress {2}, Error {3} (Units)", countInserted, countNoNh, countBadAddress, countError));

        }

        public void RemoveDeletedUnits(Dictionary<string, string> masterList)
        {
            int? countRemovedUnits=0;
            try
            {
                countRemovedUnits = unitCRUDService.RemoveDeletedUnits(masterList);
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format(">>> Can't remove units - {0}", e.Message));
            }
            Console.WriteLine(string.Format(">>> Removed {0} units", countRemovedUnits));
        }

        public List<string> GetOutterUnits(Dictionary<string, string> masterList)
        {
            return unitCRUDService.GetOutterUnits(masterList);
        }
    }
}
