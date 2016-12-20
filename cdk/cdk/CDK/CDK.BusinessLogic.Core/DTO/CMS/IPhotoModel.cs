namespace CDK.BusinessLogic.Core.DTO.CMS
{
    public interface IPhotoModel
    {
        long? Id
        {
            get; set;
        }

        string ThumbnailUri
        {
            get; set;
        }

        string LargeUri
        {
            get; set;
        }

        string SmallUri
        {
            get; set;
        }

        string PhotoName
        {
            get; set;
        }

        string PhotoAlt
        {
            get; set;
        }

        string PhotoType
        {
            get; set;
        }

        string PhotoDescription
        {
            get; set;
        }

        string Base64String
        {
            get; set;
        }
    }
}