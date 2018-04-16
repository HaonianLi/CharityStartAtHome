using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CharityStartAtHome.Models;

namespace CharityStartAtHome.Controllers
{
    public class CafesController : Controller
    {
        private Donation db = new Donation();

        // GET: Cafes
        public ActionResult Index()
        {
            return View(db.Cafes.ToList());
        }

        // GET: Cafes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cafe cafe = db.Cafes.Find(id);
            if (cafe == null)
            {
                return HttpNotFound();
            }
            return View(cafe);
        }

        // GET: Cafes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cafes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address,Area,Tradingname,Industry_Description,Latitude,Longitude")] Cafe cafe)
        {
            if (ModelState.IsValid)
            {
                db.Cafes.Add(cafe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cafe);
        }

        // GET: Cafes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cafe cafe = db.Cafes.Find(id);
            if (cafe == null)
            {
                return HttpNotFound();
            }
            return View(cafe);
        }

        // POST: Cafes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address,Area,Tradingname,Industry_Description,Latitude,Longitude")] Cafe cafe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cafe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cafe);
        }

        // GET: Cafes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cafe cafe = db.Cafes.Find(id);
            if (cafe == null)
            {
                return HttpNotFound();
            }
            return View(cafe);
        }

        // POST: Cafes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cafe cafe = db.Cafes.Find(id);
            db.Cafes.Remove(cafe);
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
