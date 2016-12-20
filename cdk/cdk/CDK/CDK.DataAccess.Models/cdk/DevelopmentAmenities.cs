namespace CDK.DataAccess.Models.cdk
{
    public class DevelopmentAmenities : BaseModel
    {
        public string Name
        {
            get; set;
        } // Name (length: 255)

        public string Description
        {
            get; set;
        } // Description

        public string IconUri
        {
            get; set;
        } // LogoUri (length: 255)

        public virtual System.Collections.Generic.ICollection<Development> Developments
        {
            get; set;
        }

        public DevelopmentAmenities()
        {
            Developments = new System.Collections.Generic.HashSet<Development>();
        }
    }
}