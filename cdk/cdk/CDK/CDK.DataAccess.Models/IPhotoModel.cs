namespace CDK.DataAccess.Models
{
    public interface IPhotoModel
    {
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

        string AltText
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
    }
}