using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDK.BusinessLogic.Core.DTO.Client;

namespace CDK.BusinessLogic.Core.ApplicationServices.Client.Interfaces
{
    public interface IClientMapService
    {
        GeoPolygon Center(SearchCriteria criteria);
        IList<GeoPolygon> Polygons(SearchCriteria criteria);
        IList<GeoMarker> Markers(SearchCriteria criteria);
        string GeoJSON(SearchCriteria criteria);
        Tuple<long, string> CenterData(SearchCriteria criteria);
        object InfoWindowData(SearchCriteria criteria, long objectId);
        object ListViewResult(SearchCriteria criteria);
        object GalleryViewResult(SearchCriteria criteria);
        object  GetStringForGallery(SearchCriteria criteria);
    }
}
