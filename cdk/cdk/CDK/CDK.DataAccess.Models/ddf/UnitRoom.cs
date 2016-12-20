using Repository.Pattern.Ef6;

namespace CDK.DataAccess.Models.ddf
{
    public class UnitRoom : Entity
    {
        public long UnitRoomId
        {
            get; set;
        }

        public long UnitId
        {
            get; set;
        }

        public long? TypeId
        {
            get; set;
        }

        public string Width
        {
            get; set;
        }

        public string Length
        {
            get; set;
        }

        public long? LevelId
        {
            get; set;
        }

        public string Dimension
        {
            get; set;
        }

        public string Description
        {
            get; set;
        }

        public System.DateTime LastUpdate
        {
            get; set;
        }

        public virtual RoomLevel RoomLevel
        {
            get; set;
        }

        public virtual RoomType RoomType
        {
            get; set;
        }

        public virtual Unit Unit
        {
            get; set;
        }
    }
}