using System;
using Repository.Pattern.Ef6;

namespace CDK.DataAccess.Models.ddf
{
    public class UnitPhoto : Entity, ISeoModel, IPhotoModel, IBaseModel, IExternalModel
    {
        public long Id
        {
            get; set;
        }

        public long UnitId
        {
            get; set;
        }

        public string DdfSequenceId
        {
            get; set;
        }

        public string DdfPropertyId
        {
            get; set;
        }

        public string ThumbnailUri
        {
            get; set;
        }

        public string LargeUri
        {
            get; set;
        }

        public string SmallUri
        {
            get; set;
        }

        public string AltText
        {
            get; set;
        }

        public string PhotoName
        {
            get; set;
        }

        public string PhotoType
        {
            get; set;
        }

        public string PhotoDescription
        {
            get; set;
        }
        
        public System.DateTime LastUpdate
        {
            get; set;
        }

        public DateTime Created
        {
            get; set;
        }

        public string CreatedBy
        {
            get; set;
        }

        public string LastUpdateBy
        {
            get; set;
        }

        public virtual Unit Unit
        {
            get; set;
        }

        public string SeoCaption
        {
            get; set;
        }

        public string SeoDescription
        {
            get; set;
        }

        public string SeoKeywords
        {
            get; set;
        }

        public string SeoSlug
        {
            get; set;
        }

        public string SeoTitle
        {
            get; set;
        }

        public string SeoMetaDescription
        {
            get; set;
        }

        public string SeoURI
        {
            get; set;
        }
               
        public System.DateTime LastExternalUpdate
        {
            get; set;
        }
    }
}