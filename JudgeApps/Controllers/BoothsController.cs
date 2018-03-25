using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JudgeApps.Models;

namespace JudgeApps.Controllers
{
    public class BoothsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Booths
        public ActionResult Index()
        {
            return View(db.Booths.ToList());
        }

        // GET: Booths/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booth booth = db.Booths.Find(id);
            if (booth == null)
            {
                return HttpNotFound();
            }
            return View(booth);
        }

        // GET: Booths/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Booths/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BoothId")] Booth booth)
        {
            if (ModelState.IsValid)
            {
                db.Booths.Add(booth);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(booth);
        }

        // GET: Booths/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booth booth = db.Booths.Find(id);
            if (booth == null)
            {
                return HttpNotFound();
            }
            return View(booth);
        }

        // POST: Booths/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BoothId")] Booth booth)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booth).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(booth);
        }

        // GET: Booths/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booth booth = db.Booths.Find(id);
            if (booth == null)
            {
                return HttpNotFound();
            }
            return View(booth);
        }

        // POST: Booths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booth booth = db.Booths.Find(id);
            db.Booths.Remove(booth);
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
