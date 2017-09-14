using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FilmBox;

namespace FilmBox.Controllers
{
    public class DevelopersController : Controller
    {
        private FilmBoxEntities db = new FilmBoxEntities();

        // GET: Developers
        public ActionResult Index()
        {
            return View(db.Developer.ToList());
        }

        // GET: Developers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Developer developer = db.Developer.Find(id);
            if (developer == null)
            {
                return HttpNotFound();
            }
            return View(developer);
        }

        // GET: Developers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Developers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Developer developer)
        {
            if (ModelState.IsValid)
            {
                db.Developer.Add(developer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(developer);
        }

        // GET: Developers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Developer developer = db.Developer.Find(id);
            if (developer == null)
            {
                return HttpNotFound();
            }
            return View(developer);
        }

        // POST: Developers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Developer developer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(developer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(developer);
        }

        // GET: Developers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Developer developer = db.Developer.Find(id);
            if (developer == null)
            {
                return HttpNotFound();
            }
            return View(developer);
        }

        // POST: Developers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Developer developer = db.Developer.Find(id);
            db.Developer.Remove(developer);
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
