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
    public class RollsController : Controller
    {
        private FilmBoxEntities db = new FilmBoxEntities();

        // GET: Rolls
        public ActionResult Index()
        {
            var roll = db.Roll.Include(r => r.Camera).Include(r => r.Developer).Include(r => r.Film).Include(r => r.Lens).Include(r => r.Speed);
            return View(roll.ToList());
        }

        // GET: Rolls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Roll roll = db.Roll.Find(id);
            if (roll == null)
            {
                return HttpNotFound();
            }
            return View(roll);
        }

        // GET: Rolls/Create
        public ActionResult Create()
        {
            ViewBag.Camera_Id = new SelectList(db.Camera, "Id", "ModelName");
            ViewBag.Developer_Id = new SelectList(db.Developer, "Id", "Name");
            ViewBag.Film_Id = new SelectList(db.Film, "Id", "Name");
            ViewBag.Lens_Id = new SelectList(db.Lens, "Id", "Name");
            ViewBag.Speed_Id = new SelectList(db.Speed, "Id", "Id");
            return View();
        }

        // POST: Rolls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SerialNumber,Film_Id,Camera_Id,Lens_Id,Speed_Id,IsExpired,Remark,IsDeveloped,Developer_Id")] Roll roll)
        {
            if (ModelState.IsValid)
            {
                db.Roll.Add(roll);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Camera_Id = new SelectList(db.Camera, "Id", "ModelName", roll.Camera_Id);
            ViewBag.Developer_Id = new SelectList(db.Developer, "Id", "Name", roll.Developer_Id);
            ViewBag.Film_Id = new SelectList(db.Film, "Id", "Name", roll.Film_Id);
            ViewBag.Lens_Id = new SelectList(db.Lens, "Id", "Name", roll.Lens_Id);
            ViewBag.Speed_Id = new SelectList(db.Speed, "Id", "Id", roll.Speed_Id);
            return View(roll);
        }

        // GET: Rolls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Roll roll = db.Roll.Find(id);
            if (roll == null)
            {
                return HttpNotFound();
            }
            ViewBag.Camera_Id = new SelectList(db.Camera, "Id", "ModelName", roll.Camera_Id);
            ViewBag.Developer_Id = new SelectList(db.Developer, "Id", "Name", roll.Developer_Id);
            ViewBag.Film_Id = new SelectList(db.Film, "Id", "Name", roll.Film_Id);
            ViewBag.Lens_Id = new SelectList(db.Lens, "Id", "Name", roll.Lens_Id);
            ViewBag.Speed_Id = new SelectList(db.Speed, "Id", "Id", roll.Speed_Id);
            return View(roll);
        }

        // POST: Rolls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SerialNumber,Film_Id,Camera_Id,Lens_Id,Speed_Id,IsExpired,Remark,IsDeveloped,Developer_Id")] Roll roll)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roll).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Camera_Id = new SelectList(db.Camera, "Id", "ModelName", roll.Camera_Id);
            ViewBag.Developer_Id = new SelectList(db.Developer, "Id", "Name", roll.Developer_Id);
            ViewBag.Film_Id = new SelectList(db.Film, "Id", "Name", roll.Film_Id);
            ViewBag.Lens_Id = new SelectList(db.Lens, "Id", "Name", roll.Lens_Id);
            ViewBag.Speed_Id = new SelectList(db.Speed, "Id", "Id", roll.Speed_Id);
            return View(roll);
        }

        // GET: Rolls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Roll roll = db.Roll.Find(id);
            if (roll == null)
            {
                return HttpNotFound();
            }
            return View(roll);
        }

        // POST: Rolls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Roll roll = db.Roll.Find(id);
            db.Roll.Remove(roll);
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
