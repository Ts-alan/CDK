using System;
using System.Collections.Generic;
using System.Linq;
using CDK.ETL.Core.Managers;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using CDK.DataAccess.Models;
using CDK.DataAccess.Repositories;
using CDK.DataAccess.Models.ddf;

namespace CDK.ETL.Core.Tests
{
    class TestManager
    {

        public void startTest()
        {

            using (var context = new CDKDbContext())
            {

                //Avoid timeout on huge request
                context.Database.CommandTimeout = 360;

                List<Unit> properties = context.Units.Take(10).ToList();
                foreach (Unit property in properties)
                {

                    try
                    {
                        //DdfUnitFactoryManager.AddUpdateUnit(property);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                    
                }
                
                Console.WriteLine("");

            }
        }
    }
}
