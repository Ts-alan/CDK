using CDK.BusinessLogic.Core.DTO.Client;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDK.BusinessLogic.Core.Extenstions
{
    internal static class GeoExtensions
    {
        internal static IEnumerable<GeoCoordinate> GetGeoCoordinatesFromPolygon(this System.Data.Entity.Spatial.DbGeography geo)
        {
            for (int i = 1; i <= geo.PointCount; i++)
            {
                var p = geo.PointAt(i);
                yield return new GeoCoordinate() { Latitude = p.Latitude.Value, Longitude = p.Longitude.Value };
            }
        }
             

        public static DbGeography ConvertRectangleToCoordinatesToPolygon(this IEnumerable<GeoCoordinate> coordinates)
        {
            if (coordinates == null || coordinates.Count() == 0 || coordinates.First() != coordinates.Last())
            {
                return null;
            }

            var coordinateList = coordinates.ToList();

            var count = 0;
            var sb = new StringBuilder();

            sb.Append(@"POLYGON((");

            foreach (var coordinate in coordinateList)
            {
                if (count == 0)
                {
                    sb.Append(coordinate.Longitude + " " + coordinate.Latitude);
                }
                else
                {
                    sb.Append("," + coordinate.Longitude + " " + coordinate.Latitude);
                }

                count++;
            }

            sb.Append(@"))");

            return DbGeography.PolygonFromText(sb.ToString(), 4326);
        }
    }
}
