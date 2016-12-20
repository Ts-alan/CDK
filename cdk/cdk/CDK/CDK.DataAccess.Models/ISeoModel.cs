namespace CDK.DataAccess.Models
{
    public interface ISeoModel
    {
        string SeoCaption
        {
            get; set;
        }

        string SeoDescription
        {
            get; set;
        }

        string SeoKeywords
        {
            get; set;
        }

        string SeoSlug
        {
            get; set;
        }

        string SeoTitle
        {
            get; set;
        }

        string SeoMetaDescription
        {
            get; set;
        }

        string SeoURI
        {
            get; set;
        }
    }
}