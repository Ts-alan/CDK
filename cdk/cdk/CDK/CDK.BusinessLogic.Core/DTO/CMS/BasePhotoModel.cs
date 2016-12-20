namespace CDK.BusinessLogic.Core.DTO.CMS
{
    public class BasePhotoModel : BaseModel, IPhotoModel
    {
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

        public string PhotoAlt
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

        public new long? Id
        {
            get; set;
        }

        public string Base64String
        {
            get; set;
        }
    }
}