using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using GeoJSON.Net.Geometry;
using GeoJSON.Net.Feature;

namespace CDK.Maponic.Core
{
    public static class WkbGeoJsonParser
    {


        public static string ParseWkbToGeoJson(List<Tuple<WkbShape, Dictionary<string, object>>> wkbs)
        {

            FeatureCollection featureCollection = new FeatureCollection();

            foreach (var wkb in wkbs)
            {

                if (wkb.Item1.Type == WkbGeometryType.WkbMultiPolygon)
                {
                    WkbMultiPolygon multiPoly = (WkbMultiPolygon) wkb.Item1;

                    List<Polygon> polys = new List<Polygon>();
                    foreach (var poly in multiPoly.Polygons)
                    {
                        List<LineString> lines = new List<LineString>();
                        foreach (var lineRings in poly.Rings)
                        {
                            List<GeographicPosition> points = new List<GeographicPosition>();
                            foreach (var point in lineRings.Points)
                            {
                                points.Add(new GeographicPosition(point.Y, point.X));
                            }
                            lines.Add(new LineString(points));
                        }

                        polys.Add(new Polygon(lines));

                    }

                    MultiPolygon multiPolygon = new MultiPolygon(polys);
                    Feature features = new Feature(multiPolygon, wkb.Item2);

                    featureCollection.Features.Add(features);

                }

                if (wkb.Item1.Type == WkbGeometryType.WkbPolygon)
                {
                    WkbPolygon poly = (WkbPolygon)wkb.Item1;
                    List<LineString> lines = new List<LineString>();
                    foreach (var lineRings in poly.Rings)
                    {
                        List<GeographicPosition> points = new List<GeographicPosition>();
                        foreach (var point in lineRings.Points)
                        {
                            points.Add(new GeographicPosition(point.Y, point.X));
                        }
                        lines.Add(new LineString(points));
                    }

                    Polygon polygon = new Polygon(lines);
                    Feature features = new Feature(polygon, wkb.Item2);

                    featureCollection.Features.Add(features);

                }
            }

            var actualJson = JsonConvert.SerializeObject(featureCollection);

            return actualJson;

        }
    }
}