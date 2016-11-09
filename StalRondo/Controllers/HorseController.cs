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
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace StalRondo.Controllers
{
    public class HorseController : Controller
    {
        private StableContext db = new StableContext();

        // GET: Horse
        public ActionResult Index()
        {
            return View(db.Herd.ToList());
        }
        public FileStreamResult ProfilePicture(int? id, Guid profilePictureID)
        {
            if (id == null || profilePictureID == null) return null;
            Horse horse = db.Herd.Find(id);
            Picture picture = horse.Pictures.FirstOrDefault(pic => pic.PictureID == horse.ProfilePictureID);
            if (picture == null) return null;

            MemoryStream stream;
            Image img;

            using (stream = new MemoryStream(picture.Data))
            {
                img = Image.FromStream(stream);

                switch (img.Width <= img.Height)
                {
                    case true:
                        img = ImgHandler.CropImage(img, new Rectangle(0, 0, img.Width, img.Width));
                        break;
                    case false:
                        img = ImgHandler.CropImage(img, new Rectangle(0, 0, img.Height, img.Height));
                        break;
                }

                img = ImgHandler.ResizeImage(img, 200, 200);
            }

            stream = new MemoryStream();
            img.Save(stream, ImageFormat.Jpeg);
            stream.Position = 0;

            return new FileStreamResult(stream, "image/jpeg");

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
            return View();
        }

        // POST: Horse/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HorseID,ProfilePictureID,Name,Gender,BirthDate")] Horse horse)
        {
            if (ModelState.IsValid)
            {
                db.Herd.Add(horse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

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
            return View(horse);
        }

        // POST: Horse/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HorseID,ProfilePictureID,Name,Gender,BirthDate")] Horse horse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(horse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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
