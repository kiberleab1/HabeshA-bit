using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HabeshaBit.Models;

namespace HabeshaBit.Controllers
{
    public class MusuicsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Musuics
        public ActionResult Index()
        {
            return View(db.Musuics.ToList());
        }

        // GET: Musuics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musuic musuic = db.Musuics.Find(id);
            if (musuic == null)
            {
                return HttpNotFound();
            }
            return View(musuic);
        }

        // GET: Musuics/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Musuics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "musiID,musicName,musicPath,album,artist,picPath")] Musuic musuic)
        {
            if (ModelState.IsValid)
            {
                db.Musuics.Add(musuic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(musuic);
        }

        // GET: Musuics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musuic musuic = db.Musuics.Find(id);
            if (musuic == null)
            {
                return HttpNotFound();
            }
            return View(musuic);
        }

        // POST: Musuics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "musiID,musicName,musicPath,album,artist,picPath")] Musuic musuic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(musuic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(musuic);
        }

        // GET: Musuics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musuic musuic = db.Musuics.Find(id);
            if (musuic == null)
            {
                return HttpNotFound();
            }
            return View(musuic);
        }

        // POST: Musuics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Musuic musuic = db.Musuics.Find(id);
            db.Musuics.Remove(musuic);
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
