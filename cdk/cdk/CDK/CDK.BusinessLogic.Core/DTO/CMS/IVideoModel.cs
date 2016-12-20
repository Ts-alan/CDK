namespace CDK.BusinessLogic.Core.DTO.CMS
{
    public interface IVideoModel
    {
        string Uri
        {
            get; set;
        }

        string Name
        {
            get; set;
        }

        string Type
        {
            get; set;
        }

        string Description
        {
            get; set;
        }

        string AltText
        {
            get; set;
        }
    }
}