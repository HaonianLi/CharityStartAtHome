using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using CharityStartAtHome.Models;

namespace CharityStartAtHome.Controllers
{
    public class ViccharitiesController : Controller
    {
        private Donation db = new Donation();

        // GET: Viccharities
        public ActionResult Index(string searchString, string currentFilter, int page = 1)
        {
            //return View(db.Viccharities.ToList());
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var time = from t in db.Viccharities
                          select t;
            if (!string.IsNullOrEmpty(searchString))
            {

                time = db.Viccharities.Where(t => t.Postcode.ToString().Contains(searchString));

            }
            int pageSize = 5;

            return View(time.ToList().ToPagedList(page, pageSize));
        }

        // GET: Viccharities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viccharity viccharity = db.Viccharities.Find(id);
            if (viccharity == null)
            {
                return HttpNotFound();
            }
            return View(viccharity);
        }

        // GET: Viccharities/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Time()
        {
            return View();
        }

        // POST: Viccharities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Orgname,Address1,Address2,Address3,City,State,Postcode,MainActivit,OtherActivity,Purposes")] Viccharity viccharity)
        {
            if (ModelState.IsValid)
            {
                db.Viccharities.Add(viccharity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viccharity);
        }

        // GET: Viccharities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viccharity viccharity = db.Viccharities.Find(id);
            if (viccharity == null)
            {
                return HttpNotFound();
            }
            return View(viccharity);
        }

        // POST: Viccharities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Orgname,Address1,Address2,Address3,City,State,Postcode,MainActivit,OtherActivity,Purposes")] Viccharity viccharity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viccharity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viccharity);
        }

        // GET: Viccharities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viccharity viccharity = db.Viccharities.Find(id);
            if (viccharity == null)
            {
                return HttpNotFound();
            }
            return View(viccharity);
        }

        // POST: Viccharities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Viccharity viccharity = db.Viccharities.Find(id);
            db.Viccharities.Remove(viccharity);
            db.SaveChanges();
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
    }
}
