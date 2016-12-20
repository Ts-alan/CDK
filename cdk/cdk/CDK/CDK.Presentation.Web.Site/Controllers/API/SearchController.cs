using AutoMapper;
using CDK.BusinessLogic.Core.ApplicationServices.Client.Interfaces;
using CDK.Presentation.Web.CMS.App_Start;
using CDK.Presentation.Web.Site.Models.Search;
using CDK.Presentation.Web.Site.Models.Search.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.UI.WebControls;
using DTO = CDK.BusinessLogic.Core.DTO.Client;

namespace CDK.Presentation.Web.Site.Controllers.API
{
    [RoutePrefix("api/Search")]
    public class SearchController : ApiController
    {
        private readonly IClientSearchService _searchService = null;
        private readonly IMapper _mapper;

        public SearchController(IClientSearchService searchService)
        {
            this._searchService = searchService;
            this._mapper = AutoMapperConfig.GetMapper();
        }


        [HttpGet]
        [Route("Areas")]
        public AreaViewModel[] Areas(string searchCreateria = null)
        {
            if (string.IsNullOrEmpty(searchCreateria) || string.IsNullOrWhiteSpace(searchCreateria))
            {
                searchCreateria = string.Empty;
            }

            return this._mapper.Map<IList<DTO.Area>, IList<AreaViewModel>>(this._searchService.FindAreas(searchCreateria, -1)).ToArray();
        }
        [HttpGet]
        [Route("GetPrice")]
        public PriceViewModel[] GetPrice()
        {
            var result = new List<PriceViewModel>();
            result.Add(new PriceViewModel() { Price = 200000 });
            result.Add(new PriceViewModel() { Price = 300000 });
            result.Add(new PriceViewModel() { Price = 400000 });
            result.Add(new PriceViewModel() { Price = 600000 });
            result.Add(new PriceViewModel() { Price = 800000 });
            result.Add(new PriceViewModel() { Price = 1000000 });
            result.Add(new PriceViewModel() { Price = 1500000 });

            return result.ToArray();
        }
        [HttpGet]
        [Route("AreaByValue")]
        public AreaViewModel AreaByValue(string value = null)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            return this._mapper.Map<DTO.Area, AreaViewModel>(this._searchService.FindAreaBySluggedValue(value));
        }

        [HttpGet]
        [Route("NeighborhoodByValue")]
        public NeighborhoodViewModel NeighborhoodByValue(string value = null)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            return this._mapper.Map<DTO.Neighborhood, NeighborhoodViewModel>(this._searchService.FindNeighborhoodBySluggedValue(value));
        }

        [HttpGet]
        [Route("PopularAreas")]
        public AreaViewModel[] PopularAreas()
        {
            return this._mapper.Map<IList<DTO.Area>, IList<AreaViewModel>>(this._searchService.GetPopularAreas()).ToArray();
        }

        [HttpGet]
        [Route("Neighborhoods")]
        public NeighborhoodViewModel[] Neighborhoods(string state = null, string area = null, string searchCreateria = null)
        {
            if (string.IsNullOrEmpty(searchCreateria) || string.IsNullOrWhiteSpace(searchCreateria))
            {
                searchCreateria = string.Empty;
            }

            if (string.IsNullOrEmpty(state) || string.IsNullOrWhiteSpace(state))
            {
                state = string.Empty;
            }

            if (string.IsNullOrEmpty(area) || string.IsNullOrWhiteSpace(area))
            {
                area = string.Empty;
            }

            return this._mapper.Map<IList<DTO.Neighborhood>, IList<NeighborhoodViewModel>>(
                this._searchService.FindNeighborhoodArea(state, area, searchCreateria))
                .ToArray();
        }


        [HttpGet]
        [Route("BedsFilter")]
        public BedFilterViewModel[] BedsFilter()
        {
            var result = new List<BedFilterViewModel>()
            {
                new  BedFilterViewModel()
                {
                    Value="studio",
                    Name= "Studio"
                },
                new  BedFilterViewModel()
                {
                    Value="1",
                    Name= "1 bedroom"
                },
                new  BedFilterViewModel()
                {
                    Value="2",
                    Name= "2 bedrooms"
                },
                new  BedFilterViewModel()
                {
                    Value="3",
                    Name= "3 bedrooms"
                },
                new  BedFilterViewModel()
                {
                    Value="4",
                    Name= "4 bedrooms"
                },
                new  BedFilterViewModel()
                {
                    Value="5+",
                    Name= "5+ bedrooms"
                },
            };

            return result.ToArray();
        }

        [HttpGet]
        [Route("GetDetailsPopup")]
        public object GetDetailsPopup(int id, MarkerTypeEnum type)
        {

            var result = _searchService.GetDetails(id, Mapper.Map<MarkerTypeEnum, DTO.MarkerEntityEnum>(type));
            return result;
        }
        [HttpGet]
        [Route("GetDetails")]
        public object GetDetails(string searchString = null)
        {

            var result = _searchService.GetDetails(searchString);
            return result;
        }
    }
}
