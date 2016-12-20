using CDK.BusinessLogic.Core.ApplicationServices.CMS.Interfaces;
using CDK.Presentation.Web.CMS.Areas.CdkEntity.Models;
using CDK.Presentation.Web.CMS.Controllers;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using DTO = CDK.BusinessLogic.Core.DTO.CMS;

namespace CDK.Presentation.Web.CMS.Areas.CdkEntity.Controllers
{
    public class DevelopersController : GenericCdkController<Developer, DTO.Developer>
    {
        public DevelopersController(ICMSApplicationService cmsService) : base(cmsService)
        {
        }
    }
}