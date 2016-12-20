using CDK.BusinessLogic.Core.ApplicationServices.CMS.Interfaces;
using CDK.Presentation.Web.CMS.Areas.CdkEntity.Models;
using CDK.Presentation.Web.CMS.Controllers;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using DTO = CDK.BusinessLogic.Core.DTO.CMS;

namespace CDK.Presentation.Web.CMS.Areas.CdkEntity.Controllers
{
    public abstract class GenericCdkController<TModel, TDtoModel> : BaseController
        where TModel : BaseModel
        where TDtoModel : DTO.BaseModel
    {
        protected GenericCdkController(ICMSApplicationService cmsService) : base(cmsService)
        {
        }

        public virtual ActionResult Index()
        {
            return View(this._mapper.Map<IList<TDtoModel>, IList<TModel>>(this._cmsService.GetCRUD<TDtoModel>().GetAll()));
        }

        public virtual ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = this._cmsService.GetCRUD<TDtoModel>().GetById(id.Value);

            if (model == null)
            {
                return HttpNotFound();
            }
            return View(this._mapper.Map<TModel>(model));
        }

        public virtual ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(TModel model)
        {
            if (ModelState.IsValid)
            {
                this._cmsService.GetCRUD<TDtoModel>().Create(this._mapper.Map<TDtoModel>(model));
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public virtual ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = this._cmsService.GetCRUD<TDtoModel>().GetById(id.Value);

            if (model == null)
            {
                return HttpNotFound();
            }
            return View(this._mapper.Map<TModel>(model));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(TModel model)
        {
            if (ModelState.IsValid)
            {
                this._cmsService.GetCRUD<TDtoModel>().Update(this._mapper.Map<TDtoModel>(model));
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public virtual ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = this._cmsService.GetCRUD<TDtoModel>().GetById(id.Value);

            if (model == null)
            {
                return HttpNotFound();
            }
            return View(this._mapper.Map<TModel>(model));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            this._cmsService.GetCRUD<TDtoModel>().DeleteById(id);
            return RedirectToAction("Index");
        }
    }
}
