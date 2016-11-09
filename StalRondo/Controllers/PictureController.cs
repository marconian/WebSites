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
using System.IO;
using System.Drawing;

namespace StalRondo.Controllers
{
    public class PictureController : Controller
    {
        private StableContext db = new StableContext();

        // GET: Pictures
        public ActionResult Index()
        {
            List<Horse> herd = db.Herd.Where(h => db.Pictures.Select(p => p.HorseID).Contains(h.HorseID)).ToList();
            int id = herd.Min(h => h.HorseID);

            List<Picture> pictures = pictures = db.Pictures.Where(p => p.HorseID == id).ToList();

            List<SelectListItem> items = new List<SelectListItem>(herd.Select(h => new SelectListItem { Value = h.HorseID.ToString(), Text = h.Name }));
            
            var viewmodel = new PictureVM
            {
                HorseID = id,
                Pictures = pictures,
                Herd = items
            };
            return View(viewmodel);
        }
        
        [HttpPost]
        public ActionResult Index(int HorseID)
        {
            List<Picture> pictures = db.Pictures.Where(p => p.HorseID == HorseID).ToList();

            if (pictures == null) return null;

            return PartialView("Gallery", pictures);
        }
        public FileStreamResult ImageFile(int? id, Guid pictureID)
        {
            if (id == null || pictureID == null) return null;
            List<Picture> pictures = db.Pictures.Where(p => p.HorseID == id).ToList();
            Picture picture = pictures.FirstOrDefault(pic => pic.PictureID == pictureID);
            if (picture == null) return null;

            MemoryStream stream = new MemoryStream(picture.Data);
            stream.Position = 0;

            return new FileStreamResult(stream, "image/jpeg");

        }

        // GET: Pictures/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = db.Pictures.Find(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            return View(picture);
        }

        // GET: Pictures/Create
        public ActionResult Create()
        {
            ViewBag.HorseID = new SelectList(db.Herd, "HorseID", "Name");
            return View();
        }

        // POST: Pictures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PictureID,HorseID,Description,Data")] Picture picture)
        {
            if (ModelState.IsValid)
            {
                picture.PictureID = Guid.NewGuid();
                db.Pictures.Add(picture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HorseID = new SelectList(db.Herd, "HorseID", "Name", picture.HorseID);
            return View(picture);
        }

        // GET: Pictures/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = db.Pictures.Find(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            ViewBag.HorseID = new SelectList(db.Herd, "HorseID", "Name", picture.HorseID);
            return View(picture);
        }

        // POST: Pictures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PictureID,HorseID,Description,Data")] Picture picture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(picture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HorseID = new SelectList(db.Herd, "HorseID", "Name", picture.HorseID);
            return View(picture);
        }

        // GET: Pictures/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = db.Pictures.Find(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            return View(picture);
        }

        // POST: Pictures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Picture picture = db.Pictures.Find(id);
            db.Pictures.Remove(picture);
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
