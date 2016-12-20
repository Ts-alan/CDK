namespace CDK.BusinessLogic.Core.DTO.Client
{
    public class Neighborhood
    {    
        public string Value
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public string ShortName
        {
            get; set;
        }

        public string Group
        {
            get;
            set;
        }

        public GeoCoordinate Center
        {
            get; set;
        }
    }
}