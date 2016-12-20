using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DTO = CDK.BusinessLogic.Core.DTO.CMS;
using CDK.BusinessLogic.Core.ApplicationServices.CMS.Interfaces;
using CDK.Presentation.Web.CMS.Areas.CdkEntity.Models;
using Newtonsoft.Json;

namespace CDK.Presentation.Web.CMS.Areas.CdkEntity.Controllers
{
    public class NeighborhoodGuidesController : GenericCdkController<NeighborhoodGuide, DTO.NeighborhoodGuide>
    {
        public NeighborhoodGuidesController(ICMSApplicationService cmsService) : base(cmsService)
        {
        }

        public override ActionResult Create()
        {
            ViewBag.NeighborhoodAreaId = new SelectList(this._cmsService.GetCRUD<DTO.NeighborhoodArea>().GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public override ActionResult Create(NeighborhoodGuide model)
        {
            model.NeighborhoodGuideVideos = JsonConvert.DeserializeObject<List<NeighborhoodGuideVideo>>(model.VideosJSON);
            model.NeighborhoodGuidePhotos = JsonConvert.DeserializeObject<List<NeighborhoodGuidePhoto>>(model.PhotoJSON);

            if (ModelState.IsValid)
            {
                //filter Videos deleted
                model.NeighborhoodGuideVideos = model.NeighborhoodGuideVideos.Where(x => !x.IsDeleted).ToList();

                for (var i = 0; i < model.NeighborhoodGuideVideos.Count(); i++)
                {
                    model.NeighborhoodGuideVideos[i].SequenceNumber = i;
                }

                //filter Photos deleted
                model.NeighborhoodGuidePhotos = model.NeighborhoodGuidePhotos.Where(x => !x.IsDeleted).ToList();

                for (var i = 0; i < model.NeighborhoodGuidePhotos.Count(); i++)
                {
                    model.NeighborhoodGuidePhotos[i].SequenceNumber = i;
                }

                this._cmsService.GetCRUD<DTO.NeighborhoodGuide>().Create(this._mapper.Map<DTO.NeighborhoodGuide>(model));
                return RedirectToAction("Index");
            }

            ViewBag.NeighborhoodAreaId = new SelectList(this._cmsService.GetCRUD<DTO.NeighborhoodArea>().GetAll(), "Id", "Name", model.NeighborhoodAreaId);
            return View(model);
        }


        public override ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var neighborhoodGuide = this._mapper.Map<NeighborhoodGuide>(this._cmsService.GetCRUD<DTO.NeighborhoodGuide>().GetById(id.Value));

            if (neighborhoodGuide == null)
            {
                return HttpNotFound();
            }


            ViewBag.NeighborhoodAreaId = new SelectList(this._cmsService.GetCRUD<DTO.NeighborhoodArea>().GetAll(), "Id", "Name", neighborhoodGuide.NeighborhoodAreaId);
            return View(neighborhoodGuide);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public override ActionResult Edit(NeighborhoodGuide model)
        {
            model.NeighborhoodGuideVideos = JsonConvert.DeserializeObject<List<NeighborhoodGuideVideo>>(model.VideosJSON);
            model.NeighborhoodGuidePhotos = JsonConvert.DeserializeObject<List<NeighborhoodGuidePhoto>>(model.PhotoJSON);

            if (ModelState.IsValid)
            {
                //filter Videos deleted
                model.NeighborhoodGuideVideos = model.NeighborhoodGuideVideos.Where(x => !x.IsDeleted).ToList();

                for (var i = 0; i < model.NeighborhoodGuideVideos.Count(); i++)
                {
                    model.NeighborhoodGuideVideos[i].SequenceNumber = i;
                }

                //filter Photos deleted
                model.NeighborhoodGuidePhotos = model.NeighborhoodGuidePhotos.Where(x => !x.IsDeleted).ToList();

                for (var i = 0; i < model.NeighborhoodGuidePhotos.Count(); i++)
                {
                    model.NeighborhoodGuidePhotos[i].SequenceNumber = i;
                }
                
                this._cmsService.GetCRUD<DTO.NeighborhoodGuide>().Update(this._mapper.Map<DTO.NeighborhoodGuide>(model));
                return RedirectToAction("Index");
            }

            ViewBag.NeighborhoodAreaId = new SelectList(this._cmsService.GetCRUD<DTO.NeighborhoodArea>().GetAll(), "Id", "Name", model.NeighborhoodAreaId);
            return View(model);
        }
    }
}
