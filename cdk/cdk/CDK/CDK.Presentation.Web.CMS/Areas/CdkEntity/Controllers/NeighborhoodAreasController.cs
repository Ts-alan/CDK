using CDK.BusinessLogic.Core.ApplicationServices.CMS.Interfaces;
using CDK.Presentation.Web.CMS.Areas.CdkEntity.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DTO = CDK.BusinessLogic.Core.DTO.CMS;

namespace CDK.Presentation.Web.CMS.Areas.CdkEntity.Controllers
{
    public class NeighborhoodAreasController : GenericCdkController<NeighborhoodArea, DTO.NeighborhoodArea>
    {
        public NeighborhoodAreasController(ICMSApplicationService cmsService) : base(cmsService)
        {
        }

        // GET: /CdkEntity/NeighborhoodAreas/Create
        public override ActionResult Create()
        {
            ViewBag.MetroAreaId = new SelectList(this._cmsService.GetCRUD<DTO.MetroArea>().GetAll(), "Id", "Name");
            return View();
        }

        public override ActionResult Create(NeighborhoodArea model)
        {
            if (ModelState.IsValid)
            {
                this._cmsService.GetCRUD<DTO.NeighborhoodArea>().Create(this._mapper.Map<DTO.NeighborhoodArea>(model));
                return RedirectToAction("Index");
            }

            ViewBag.MetroAreaId = new SelectList(this._cmsService.GetCRUD<DTO.MetroArea>().GetAll(), "Id", "Name", model.MetroAreaId);
            return View(model);
        }

        public override ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var neighborhoodArea = this._mapper.Map<NeighborhoodArea>(this._cmsService.GetCRUD<DTO.NeighborhoodArea>().GetById(id.Value));

            if (neighborhoodArea == null)
            {
                return HttpNotFound();
            }

            ViewBag.MetroAreaId = new SelectList(this._cmsService.GetCRUD<DTO.MetroArea>().GetAll(), "Id", "Name", neighborhoodArea.MetroAreaId);
            return View(neighborhoodArea);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public override ActionResult Edit(NeighborhoodArea model)
        {
            if (ModelState.IsValid)
            {
                this._cmsService.GetCRUD<DTO.NeighborhoodArea>().Update(this._mapper.Map<DTO.NeighborhoodArea>(model));
                return RedirectToAction("Index");
            }


            ViewBag.MetroAreaId = new SelectList(this._cmsService.GetCRUD<DTO.MetroArea>().GetAll(), "Id", "Name", model.MetroAreaId);
            return View(model);
        }
    }
}
