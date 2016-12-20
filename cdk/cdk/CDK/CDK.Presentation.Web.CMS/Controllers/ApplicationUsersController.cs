using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CDK.Presentation.Web.CMS.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;

namespace CDK.Presentation.Web.CMS.Controllers
{
    [Authorize]
    public class ApplicationUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Users/
        public ActionResult Index()
        {
            
            return View(db.Users.ToList());
        }

        // GET: /Users/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // GET: /Users/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var store = new UserStore<ApplicationUser>(db);
                var manager = new UserManager<ApplicationUser>(store);

                var user = new ApplicationUser() { UserName = model.UserName };
                var result = await manager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    manager.AddToRole(user.Id, "Admin");

                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrors(result);
                }
            }
            return View(model);
        }

        // GET: /Users/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(new ManageApplicationUserViewModel { Username = applicationUser.UserName, Email = applicationUser.Email, Phone = applicationUser.PhoneNumber, Id = applicationUser.Id });
        }

        // POST: /Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ManageApplicationUserViewModel applicationUser)
        {
            if (ModelState.IsValid)
            {
                var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
                var manager = new UserManager<ApplicationUser>(store);

                ApplicationUser model = manager.FindById(applicationUser.Id);

                model.Email = applicationUser.Email;
                model.PhoneNumber = applicationUser.Phone;
                model.UserName = applicationUser.Username;

                if (!string.IsNullOrEmpty(applicationUser.NewPassword))
                {
                    var hashedNewPassword = manager.PasswordHasher.HashPassword(applicationUser.NewPassword);
                    await store.SetPasswordHashAsync(model, hashedNewPassword);

                }

                await manager.UpdateAsync(model);

                var ctx = store.Context;

                await ctx.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View(applicationUser);
        }

        // GET: /Users/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: /Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var manager = new UserManager<ApplicationUser>(store);

            ApplicationUser model = manager.FindById(id);

            manager.Delete(model);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}
