using CDK.DataAccess.Models.ddf;
using CDK.ETL.DDF.DdfRawModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDK.ETL.Core.Extenstions
{
    static class UnitRoomExtensions
    {

        public static void Map(this UnitRoom unitRoom, PropertyBuildingRoom model)
        {
            unitRoom.Width = model.Width;
            unitRoom.Dimension = model.Dimension;
            unitRoom.Description = model.Description;
            unitRoom.LastUpdate = DateTime.Now;
        }

        public static void MapAll(this List<UnitRoom> unitRooms, List<PropertyBuildingRoom> models)
        {
            models.ToList().ForEach(model =>
            {
                UnitRoom unitRoom = new UnitRoom();
                unitRoom.Map(model);
                unitRooms.Add(unitRoom);
            });
        }
    }
}
