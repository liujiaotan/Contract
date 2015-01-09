using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Contract.Models;

namespace Contract.Controllers
{
    public class RoomCategoriesController : BaseController
    {
        private ContractTransferContext db = new ContractTransferContext();

        // GET: RoomCategories
        public ActionResult Index()
        {
            return View(db.RoomCategories.ToList());
        }

        // GET: RoomCategories/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomCategory roomCategory = db.RoomCategories.Find(id);
            if (roomCategory == null)
            {
                return HttpNotFound();
            }
            return View(roomCategory);
        }

        // GET: RoomCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoomCategories/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")] RoomCategory roomCategory)
        {
            if (ModelState.IsValid)
            {
                db.RoomCategories.Add(roomCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(roomCategory);
        }

        // GET: RoomCategories/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomCategory roomCategory = db.RoomCategories.Find(id);
            if (roomCategory == null)
            {
                return HttpNotFound();
            }
            return View(roomCategory);
        }

        // POST: RoomCategories/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,CreateDate")] RoomCategory roomCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roomCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roomCategory);
        }

        // GET: RoomCategories/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomCategory roomCategory = db.RoomCategories.Find(id);
            if (roomCategory == null)
            {
                return HttpNotFound();
            }
            return View(roomCategory);
        }

        // POST: RoomCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            RoomCategory roomCategory = db.RoomCategories.Find(id);
            db.RoomCategories.Remove(roomCategory);
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
