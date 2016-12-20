using CDK.DataAccess.Models.ddf;
using CDK.ETL.DDF.DdfRawModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDK.ETL.Core.Extenstions
{
    static class UnitPhotoExtensions
    {

        public static void Map(this UnitPhoto unitPhoto, PropertyPhoto propertyPhoto)
        {

            unitPhoto.DdfSequenceId = propertyPhoto.DdfSequenceId;
            unitPhoto.AltText = "";
            unitPhoto.SeoCaption = "";
            unitPhoto.SeoDescription = "";
            unitPhoto.SeoKeywords = "";
            unitPhoto.SeoSlug = "";
            unitPhoto.SeoMetaDescription = "";
            unitPhoto.SeoTitle = "";
            unitPhoto.SeoURI = "";
            unitPhoto.LastExternalUpdate = propertyPhoto.LastDdfUpdate;
            unitPhoto.LastUpdate = DateTime.Now;
            
        }

        public static void MapAll(this List<UnitPhoto> unitPhotos, List<PropertyPhoto> models)
        {
            models.ToList().ForEach(model =>
            {
                UnitPhoto unitPhoto = new UnitPhoto();
                unitPhoto.Map(model);
                unitPhotos.Add(unitPhoto);
            });
        }
    }
}
