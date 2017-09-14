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
    public class CamerasController : Controller
    {
        private FilmBoxEntities db = new FilmBoxEntities();

        // GET: Cameras
        public ActionResult Index()
        {
            var camera = db.Camera.Include(c => c.Manufacturer);
            return View(camera.ToList());
        }

        // GET: Cameras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Camera camera = db.Camera.Find(id);
            if (camera == null)
            {
                return HttpNotFound();
            }
            return View(camera);
        }

        // GET: Cameras/Create
        public ActionResult Create()
        {
            ViewBag.Manufacturer_Id = new SelectList(db.Manufacturer, "Id", "Name");
            return View();
        }

        // POST: Cameras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Manufacturer_Id,ModelName,Remark")] Camera camera)
        {
            if (ModelState.IsValid)
            {
                db.Camera.Add(camera);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Manufacturer_Id = new SelectList(db.Manufacturer, "Id", "Name", camera.Manufacturer_Id);
            return View(camera);
        }

        // GET: Cameras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Camera camera = db.Camera.Find(id);
            if (camera == null)
            {
                return HttpNotFound();
            }
            ViewBag.Manufacturer_Id = new SelectList(db.Manufacturer, "Id", "Name", camera.Manufacturer_Id);
            return View(camera);
        }

        // POST: Cameras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Manufacturer_Id,ModelName,Remark")] Camera camera)
        {
            if (ModelState.IsValid)
            {
                db.Entry(camera).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Manufacturer_Id = new SelectList(db.Manufacturer, "Id", "Name", camera.Manufacturer_Id);
            return View(camera);
        }

        // GET: Cameras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Camera camera = db.Camera.Find(id);
            if (camera == null)
            {
                return HttpNotFound();
            }
            return View(camera);
        }

        // POST: Cameras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Camera camera = db.Camera.Find(id);
            db.Camera.Remove(camera);
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
