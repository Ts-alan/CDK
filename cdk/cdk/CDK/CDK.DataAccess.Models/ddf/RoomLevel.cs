using Repository.Pattern.Ef6;

namespace CDK.DataAccess.Models.ddf
{
    public class RoomLevel : Entity, IDdfMetadata
    {
        public long Id
        {
            get; set;
        }

        public string Value
        {
            get; set;
        }

        public string ShortName
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public string AlternateName
        {
            get; set;
        }

        public string ImgUrl
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<UnitRoom> UnitRooms
        {
            get; set;
        }

        public RoomLevel()
        {
            UnitRooms = new System.Collections.Generic.HashSet<UnitRoom>();
        }
    }
}