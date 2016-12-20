using AutoMapper;
using CDK.BusinessLogic.Core.ApplicationServices.CMS.Interfaces;
using CDK.Presentation.Web.CMS.App_Start;
using System.Web.Mvc;

namespace CDK.Presentation.Web.CMS.Controllers
{
    [Authorize]
    public abstract class BaseController : Controller
    {
        protected readonly ICMSApplicationService _cmsService;
        protected readonly IMapper _mapper;

        protected BaseController(ICMSApplicationService cmsService)
        {
            this._cmsService = cmsService;
            this._mapper = AutoMapperConfig.GetMapper();
        }
    }
}