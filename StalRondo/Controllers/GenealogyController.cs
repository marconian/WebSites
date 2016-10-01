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
using StalRondo.ViewModels;

namespace StalRondo.Controllers
{
    public class GenealogyController : Controller
    {
        private StableContext db = new StableContext();

        // GET: Genealogie
        public ActionResult Index()
        {
            var genealogyTree = db.GenealogyTree.Include(g => g.Father).Include(g => g.Horse).Include(g => g.Mother);
            return View(genealogyTree.ToList());
        }

        // GET: Genealogie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Genealogy horse = db.GenealogyTree.Find(id);
            GenealogyTree genealogyTree = new GenealogyTree(horse);

            if (genealogyTree.Horse == null) return HttpNotFound();

            return PartialView(genealogyTree);
        }

        // GET: Genealogie/Create
        public ActionResult Create()
        {
            ViewBag.FatherID = new SelectList(db.Herd, "HorseID", "Name");
            ViewBag.HorseID = new SelectList(db.Herd, "HorseID", "Name");
            ViewBag.MotherID = new SelectList(db.Herd, "HorseID", "Name");
            return View();
        }

        // POST: Genealogie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HorseID,FatherID,MotherID")] Genealogy genealogy)
        {
            if (ModelState.IsValid)
            {
                db.GenealogyTree.Add(genealogy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FatherID = new SelectList(db.Herd, "HorseID", "Name", genealogy.FatherID);
            ViewBag.HorseID = new SelectList(db.Herd, "HorseID", "Name", genealogy.HorseID);
            ViewBag.MotherID = new SelectList(db.Herd, "HorseID", "Name", genealogy.MotherID);
            return View(genealogy);
        }

        // GET: Genealogie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genealogy genealogy = db.GenealogyTree.Find(id);
            if (genealogy == null)
            {
                return HttpNotFound();
            }
            ViewBag.FatherID = new SelectList(db.Herd, "HorseID", "Name", genealogy.FatherID);
            ViewBag.HorseID = new SelectList(db.Herd, "HorseID", "Name", genealogy.HorseID);
            ViewBag.MotherID = new SelectList(db.Herd, "HorseID", "Name", genealogy.MotherID);
            return View(genealogy);
        }

        // POST: Genealogie/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HorseID,FatherID,MotherID")] Genealogy genealogy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(genealogy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FatherID = new SelectList(db.Herd, "HorseID", "Name", genealogy.FatherID);
            ViewBag.HorseID = new SelectList(db.Herd, "HorseID", "Name", genealogy.HorseID);
            ViewBag.MotherID = new SelectList(db.Herd, "HorseID", "Name", genealogy.MotherID);
            return View(genealogy);
        }

        // GET: Genealogie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genealogy genealogy = db.GenealogyTree.Find(id);
            if (genealogy == null)
            {
                return HttpNotFound();
            }
            return View(genealogy);
        }

        // POST: Genealogie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Genealogy genealogy = db.GenealogyTree.Find(id);
            db.GenealogyTree.Remove(genealogy);
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
