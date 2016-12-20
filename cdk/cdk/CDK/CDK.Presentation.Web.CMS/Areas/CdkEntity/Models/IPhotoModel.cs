namespace CDK.Presentation.Web.CMS.Areas.CdkEntity.Models
{
    public interface IPhotoModel
    {
        string Base64String
        {
            get;
            set;
        }
        bool IsDeleted
        {
            get;
            set;
        }
        string LargeUri
        {
            get;
            set;
        }
        string PhotoAlt
        {
            get;
            set;
        }
        string PhotoDescription
        {
            get;
            set;
        }
        string PhotoName
        {
            get;
            set;
        }
        string PhotoType
        {
            get;
            set;
        }
        string SmallUri
        {
            get;
            set;
        }
        string ThumbnailUri
        {
            get;
            set;
        }
    }
}