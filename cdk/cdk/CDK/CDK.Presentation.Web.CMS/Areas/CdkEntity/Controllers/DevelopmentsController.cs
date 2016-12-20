using CDK.BusinessLogic.Core.ApplicationServices.CMS.Interfaces;
using CDK.Presentation.Web.CMS.Areas.CdkEntity.Models;
using CDK.Presentation.Web.CMS.Controllers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DTO = CDK.BusinessLogic.Core.DTO.CMS;

namespace CDK.Presentation.Web.CMS.Areas.CdkEntity.Controllers
{
    public class DevelopmentsController : GenericCdkController<Development, DTO.Development>
    {
        public DevelopmentsController(ICMSApplicationService cmsService) : base(cmsService)
        {
        }

        public override ActionResult Create()
        {
            ViewBag.DeveloperId = new SelectList(this._cmsService.GetCRUD<DTO.Developer>().GetAll(), "Id", "Name");
            ViewBag.NeighborhoodAreas = new SelectList(this._cmsService.GetCRUD<DTO.NeighborhoodArea>().GetAll(), "Id", "Name");
            ViewBag.AmenitiesDropdown = new MultiSelectList(this._cmsService.GetCRUD<DTO.DevelopmentAmenities>().GetAll(), "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public override ActionResult Create(Development model)
        {
            model.DevelopmentVideos = JsonConvert.DeserializeObject<List<DevelopmentVideo>>(model.VideosJSON);
            model.DevelopmentPhotos = JsonConvert.DeserializeObject<List<DevelopmentPhoto>>(model.PhotoJSON);
            model.DevelopmentFloorPlans = JsonConvert.DeserializeObject<List<DevelopmentFloorPlan>>(model.FloorsPlanJSON);

            if (ModelState.IsValid)
            {
                //filter deleted
                model.DevelopmentVideos = model.DevelopmentVideos.Where(x => !x.IsDeleted).ToList();

                for (var i = 0; i < model.DevelopmentVideos.Count(); i++)
                {
                    model.DevelopmentVideos[i].SequenceNumber = i;
                }


                //filter Photos deleted
                model.DevelopmentPhotos = model.DevelopmentPhotos.Where(x => !x.IsDeleted).ToList();

                for (var i = 0; i < model.DevelopmentPhotos.Count(); i++)
                {
                    model.DevelopmentPhotos[i].SequenceNumber = i;
                }

                //filter Floors deleted
                model.DevelopmentFloorPlans = model.DevelopmentFloorPlans.Where(x => !x.IsDeleted).ToList();

                for (var i = 0; i < model.DevelopmentFloorPlans.Count(); i++)
                {
                    model.DevelopmentFloorPlans[i].SequenceNumber = i;
                }

                this._cmsService.GetCRUD<DTO.Development>().Create(this._mapper.Map<DTO.Development>(model));
                return RedirectToAction("Index");
            }

            ViewBag.DeveloperId = new SelectList(this._cmsService.GetCRUD<DTO.Developer>().GetAll(), "Id", "Name");
            ViewBag.NeighborhoodAreas = new SelectList(this._cmsService.GetCRUD<DTO.NeighborhoodArea>().GetAll(), "Id", "Name");
            ViewBag.AmenitiesDropdown = new MultiSelectList(this._cmsService.GetCRUD<DTO.DevelopmentAmenities>().GetAll(), "Id", "Name");

            return View(model);
        }

        public override ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var development = this._mapper.Map<Development>(this._cmsService.GetCRUD<DTO.Development>().GetById(id.Value));

            if (development == null)
            {
                return HttpNotFound();
            }

            ViewBag.DeveloperId = new SelectList(this._cmsService.GetCRUD<DTO.Developer>().GetAll(), "Id", "Name", development.DeveloperId);
            ViewBag.NeighborhoodAreas = new SelectList(this._cmsService.GetCRUD<DTO.NeighborhoodArea>().GetAll(), "Id", "Name");
            ViewBag.AmenitiesDropdown = new MultiSelectList(this._cmsService.GetCRUD<DTO.DevelopmentAmenities>().GetAll(), "Id", "Name");

            return View(development);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public override ActionResult Edit(Development model)
        {
            model.DevelopmentVideos = JsonConvert.DeserializeObject<List<DevelopmentVideo>>(model.VideosJSON);
            model.DevelopmentPhotos = JsonConvert.DeserializeObject<List<DevelopmentPhoto>>(model.PhotoJSON);
            model.DevelopmentFloorPlans = JsonConvert.DeserializeObject<List<DevelopmentFloorPlan>>(model.FloorsPlanJSON);

            if (ModelState.IsValid)
            {
                //filter deleted
                model.DevelopmentVideos = model.DevelopmentVideos.Where(x => !x.IsDeleted).ToList();

                for (var i = 0; i < model.DevelopmentVideos.Count(); i++)
                {
                    model.DevelopmentVideos[i].SequenceNumber = i;
                }

                //filter Photos deleted
                model.DevelopmentPhotos = model.DevelopmentPhotos.Where(x => !x.IsDeleted).ToList();

                for (var i = 0; i < model.DevelopmentPhotos.Count(); i++)
                {
                    model.DevelopmentPhotos[i].SequenceNumber = i;
                }

                //filter Floors deleted
                model.DevelopmentFloorPlans = model.DevelopmentFloorPlans.Where(x => !x.IsDeleted).ToList();

                for (var i = 0; i < model.DevelopmentFloorPlans.Count(); i++)
                {
                    model.DevelopmentFloorPlans[i].SequenceNumber = i;
                }

                this._cmsService.GetCRUD<DTO.Development>().Update(this._mapper.Map<DTO.Development>(model));
                return RedirectToAction("Index");
            }

            ViewBag.DeveloperId = new SelectList(this._cmsService.GetCRUD<DTO.Developer>().GetAll(), "Id", "Name");
            ViewBag.NeighborhoodAreas = new SelectList(this._cmsService.GetCRUD<DTO.NeighborhoodArea>().GetAll(), "Id", "Name");
            ViewBag.AmenitiesDropdown = new MultiSelectList(this._cmsService.GetCRUD<DTO.DevelopmentAmenities>().GetAll(), "Id", "Name");

            return View(model);
        }
    }
}