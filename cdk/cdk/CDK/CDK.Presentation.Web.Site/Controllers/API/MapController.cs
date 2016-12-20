using AutoMapper;
using CDK.BusinessLogic.Core.ApplicationServices.Client.Interfaces;
using CDK.Presentation.Web.CMS.App_Start;
using CDK.Presentation.Web.Site.Models.Search;
using CDK.Presentation.Web.Site.Models.Search.Binders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using DTO = CDK.BusinessLogic.Core.DTO.Client;

namespace CDK.Presentation.Web.Site.Controllers.API
{
    [RoutePrefix("api/Search/Map")]
    public class MapController : ApiController
    {
        private readonly IClientSearchService _searchService = null;
        private readonly IClientMapService _mapService = null;
        private readonly IMapper _mapper;

        public MapController(IClientSearchService searchService, IClientMapService mapService)
        {
            this._searchService = searchService;
            this._mapService = mapService;
            this._mapper = AutoMapperConfig.GetMapper();
        }


        #region MapPart

        [HttpGet]
        [Route("Center")]
        public GeoPolygonViewModel Center(
            [FromUri(BinderType = typeof(SearchFilterModelBinder))] SearchFilterBindingModel filter)
        {
            GeoPolygonViewModel center = null;


            center = this._mapper.Map<DTO.GeoPolygon, GeoPolygonViewModel>(
                this._mapService.Center(
                    this._mapper.Map<SearchFilterBindingModel, DTO.SearchCriteria>(filter)));

            if (center == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return center;
        }

        [HttpGet]
        [Route("Polygons")]
        public IList<GeoPolygonViewModel> Polygons(
            [FromUri(BinderType = typeof(SearchFilterModelBinder))] SearchFilterBindingModel filter)
        {
            //var watch = System.Diagnostics.Stopwatch.StartNew();
            //watch.Stop();
            //var elapsedMs = watch.ElapsedMilliseconds;

            var result = this._mapper.Map<IList<DTO.GeoPolygon>, IList<GeoPolygonViewModel>>(
               this._mapService.Polygons(this._mapper.Map<SearchFilterBindingModel, DTO.SearchCriteria>(filter))).ToList();

            return result;
        }

        [HttpGet]
        [Route("Markers")]
        public IList<GeoMarkerViewModel> Markers(
            [FromUri(BinderType = typeof(SearchFilterModelBinder))] SearchFilterBindingModel filter)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();


            var result = this._mapper.Map<IList<DTO.GeoMarker>, IList<GeoMarkerViewModel>>(
               this._mapService.Markers(this._mapper.Map<SearchFilterBindingModel, DTO.SearchCriteria>(filter))).ToList();

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            return result;
        }

        [HttpGet]
        [Route("Geojson")]
        public HttpResponseMessage GeoJSON(
            [FromUri(BinderType = typeof(SearchFilterModelBinder))] SearchFilterBindingModel filter)
        {
            var json = _mapService.GeoJSON(this._mapper.Map<SearchFilterBindingModel, DTO.SearchCriteria>(filter));

            var stream = GenerateStreamFromString(json);
            var result = Request.CreateResponse(HttpStatusCode.OK);
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return result;
        }

        [HttpGet]
        [Route("CenterData")]
        public object CenterData(
            [FromUri(BinderType = typeof(SearchFilterModelBinder))] SearchFilterBindingModel filter)
        {
            var result = this._mapService.CenterData(
                    this._mapper.Map<SearchFilterBindingModel, DTO.SearchCriteria>(filter));
            return result != null ? new
            {
                Id = result.Item1,
                Type = result.Item2
            } : new object();
        }

        [HttpGet]
        [Route("InfoWindowData")]
        public object InfoWindowData(
            [FromUri(BinderType = typeof(SearchFilterModelBinder))] SearchFilterBindingModel filter, long objectId)
        {
            var result = this._mapService.InfoWindowData(
                    this._mapper.Map<SearchFilterBindingModel, DTO.SearchCriteria>(filter), objectId);
            return result;
        }

        [HttpGet]
        [Route("ListView")]
        public object ListView(
            [FromUri(BinderType = typeof(SearchFilterModelBinder))] SearchFilterBindingModel filter)
        {
            var result = this._mapService.ListViewResult(
                    this._mapper.Map<SearchFilterBindingModel, DTO.SearchCriteria>(filter));
            return result;
        }

        [HttpGet]
        [Route("GalleryView")]
        public object GalleryView(
            [FromUri(BinderType = typeof(SearchFilterModelBinder))] SearchFilterBindingModel filter)
        {
            var result = this._mapService.ListViewResult(
                    this._mapper.Map<SearchFilterBindingModel, DTO.SearchCriteria>(filter));
            return result;
        }
        [HttpGet]
        [Route("GetStringForGallery")]
        public object GetStringForGallery(
           [FromUri(BinderType = typeof(SearchFilterModelBinder))] SearchFilterBindingModel filter)
        {
            var result = this._mapService.GetStringForGallery(
                  this._mapper.Map<SearchFilterBindingModel, DTO.SearchCriteria>(filter));
            return result;
        }
        #endregion

        private Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

    }
}
