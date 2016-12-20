using CDK.BusinessLogic.Core.ApplicationServices.CMS.Interfaces;
using CDK.Presentation.Web.CMS.Areas.CdkEntity.Models;
using CDK.Presentation.Web.CMS.Controllers;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using DTO = CDK.BusinessLogic.Core.DTO.CMS;

namespace CDK.Presentation.Web.CMS.Areas.CdkEntity.Controllers
{
    public class DevelopmentAmenitiesController : GenericCdkController<DevelopmentAmenities, DTO.DevelopmentAmenities>
    {
        public DevelopmentAmenitiesController(ICMSApplicationService cmsService) : base(cmsService)
        {
        }

        public override ActionResult Create()
        {
            ViewBag.Amenities = new SelectList(this._cmsService.GetDevelopmentAmenitiesImagesList(), "Key", "Value");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public override ActionResult Create(DevelopmentAmenities model)
        {
            if (ModelState.IsValid)
            {
                this._cmsService.GetCRUD<DTO.DevelopmentAmenities>().Create(this._mapper.Map<DTO.DevelopmentAmenities>(model));
                return RedirectToAction("Index");
            }

            ViewBag.Amenities = new SelectList(this._cmsService.GetDevelopmentAmenitiesImagesList(), "Key", "Value");

            return View(model);
        }

        public override ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var development = this._mapper.Map<DevelopmentAmenities>(this._cmsService.GetCRUD<DTO.DevelopmentAmenities>().GetById(id.Value));

            if (development == null)
            {
                return HttpNotFound();
            }

            ViewBag.Amenities = new SelectList(this._cmsService.GetDevelopmentAmenitiesImagesList(), "Key", "Value");

            return View(development);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public override ActionResult Edit(DevelopmentAmenities model)
        {
            if (ModelState.IsValid)
            {
                this._cmsService.GetCRUD<DTO.DevelopmentAmenities>().Update(this._mapper.Map<DTO.DevelopmentAmenities>(model));
                return RedirectToAction("Index");
            }
            ViewBag.Amenities = new SelectList(this._cmsService.GetDevelopmentAmenitiesImagesList(), "Key", "Value");

            return View(model);
        }
    }
}
