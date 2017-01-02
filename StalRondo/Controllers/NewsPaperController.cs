using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StalRondo.DAL;
using StalRondo.Models;

namespace StalRondo.Controllers
{
    public class NewsPaperController : Controller
    {
        private StableContext db = new StableContext();

        // GET: NewsPaper
        public async Task<ActionResult> Index()
        {
            var newsPaper = db.NewsPaper.Include(a => a.Author).Include(a => a.Picture);
            return View(await newsPaper.ToListAsync());
        }

        // GET: NewsPaper/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = await db.NewsPaper.FindAsync(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // GET: NewsPaper/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.UserStore, "UserID", "SurName");
            ViewBag.PictureID = new SelectList(db.Pictures, "PictureID", "Description");
            return View();
        }

        // POST: NewsPaper/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ArticleID,UserID,PictureID,Title,PublishDate,Content")] Article article)
        {
            if (ModelState.IsValid)
            {
                article.ArticleID = Guid.NewGuid();
                db.NewsPaper.Add(article);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.UserStore, "UserID", "SurName", article.UserID);
            ViewBag.PictureID = new SelectList(db.Pictures, "PictureID", "Description", article.PictureID);
            return View(article);
        }

        // GET: NewsPaper/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = await db.NewsPaper.FindAsync(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.UserStore, "UserID", "SurName", article.UserID);
            ViewBag.PictureID = new SelectList(db.Pictures, "PictureID", "Description", article.PictureID);
            return View(article);
        }

        // POST: NewsPaper/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ArticleID,UserID,PictureID,Title,PublishDate,Content")] Article article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.UserStore, "UserID", "SurName", article.UserID);
            ViewBag.PictureID = new SelectList(db.Pictures, "PictureID", "Description", article.PictureID);
            return View(article);
        }

        // GET: NewsPaper/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = await db.NewsPaper.FindAsync(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: NewsPaper/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Article article = await db.NewsPaper.FindAsync(id);
            db.NewsPaper.Remove(article);
            await db.SaveChangesAsync();
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
