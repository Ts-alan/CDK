using CDK.DataAccess.Models;
using CDK.DataAccess.Repositories;
using CDK.ETL.DDF.Property;
using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDK.ETL.Core.Extenstions
{
    public static class MetadataExtensions
    {
        public static void Map<TType>(this RETSMetadataLookupType lookupType, ref TType model)
            where TType : class, IDdfMetadata
        {
            if (model != null)
            {
                model.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Modified;
            }
            else
            {
                model = (TType)Activator.CreateInstance(typeof(TType), new object[] { });
                model.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Added;
            }

            model.Id = long.Parse(lookupType.MetadataEntryID);
            model.Name = lookupType.LongValue;
            model.ShortName = lookupType.ShortValue;
            model.Value = lookupType.Value;

        }

        public static void MapAll<TType>(this List<RETSMetadataLookupType> lookupTypeList, UnitOfWork uow)
            where TType : class, IDdfMetadata
        {
            var repo = uow.Repository<TType>();

            var models = repo.Query().Select().ToList();

            int count=0;
            lookupTypeList.ForEach(lookup =>
            {
                var model = models.FirstOrDefault(i => i.Id.ToString() == lookup.MetadataEntryID);

                lookup.Map(ref model);

                if (model.ObjectState == Repository.Pattern.Infrastructure.ObjectState.Added)
                {
                    repo.Insert(model);
                }

                if (model.ObjectState == Repository.Pattern.Infrastructure.ObjectState.Modified)
                {
                    repo.Update(model);
                }

                count++;

            });

            uow.SaveChanges();
            Console.WriteLine(string.Format(">>> INSERTED/UPDATED ({0}) METADATA", count));

        }

        public static void MergeAllFromLookupType<TType>(this List<RETSMetadataLookupType> lookupTypeList)
            where TType : class, IDdfMetadata
        {
            using (var context = new CDKDbContext())
            using (var uow = new UnitOfWork(context))
            {
                lookupTypeList.MapAll<TType>(uow);
            }
        }

        public static void TryToMergeAllFromLookupType<TType>(this List<RETSMetadataLookupType> lookupTypeList)
           where TType : class, IDdfMetadata
        {
            try
            {
                lookupTypeList.MergeAllFromLookupType<TType>();
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format(">>> CAN'T INSERT METADATA ({0}): {1}", typeof(TType).Name, e));
            }
        }
    }
}
