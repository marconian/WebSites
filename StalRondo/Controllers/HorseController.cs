using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StalRondo.DAL;
using StalRondo.Models;

namespace StalRondo.Controllers
{
    public class HorseController : Controller
    {
        private StableContext db = new StableContext();

        // GET: Horse
        public ActionResult Index()
        {
            var herd = db.Herd.Include(h => h.Genealogy);
            return View(herd.ToList());
        }

        // GET: Horse/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horse horse = db.Herd.Find(id);
            if (horse == null)
            {
                return HttpNotFound();
            }
            return View(horse);
        }

        // GET: Horse/Create
        public ActionResult Create()
        {
            ViewBag.HorseID = new SelectList(db.GenealogyTree, "HorseID", "HorseID");
            return View();
        }

        // POST: Horse/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HorseID,Name,Gender,BirthDate")] Horse horse)
        {
            if (ModelState.IsValid)
            {
                db.Herd.Add(horse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HorseID = new SelectList(db.GenealogyTree, "HorseID", "HorseID", horse.HorseID);
            return View(horse);
        }

        // GET: Horse/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horse horse = db.Herd.Find(id);
            if (horse == null)
            {
                return HttpNotFound();
            }
            ViewBag.HorseID = new SelectList(db.GenealogyTree, "HorseID", "HorseID", horse.HorseID);
            return View(horse);
        }

        // POST: Horse/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HorseID,Name,Gender,BirthDate")] Horse horse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(horse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HorseID = new SelectList(db.GenealogyTree, "HorseID", "HorseID", horse.HorseID);
            return View(horse);
        }

        // GET: Horse/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horse horse = db.Herd.Find(id);
            if (horse == null)
            {
                return HttpNotFound();
            }
            return View(horse);
        }

        // POST: Horse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Horse horse = db.Herd.Find(id);
            db.Herd.Remove(horse);
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
