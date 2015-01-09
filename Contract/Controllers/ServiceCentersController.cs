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
    public class ServiceCentersController : BaseController
    {
        private ContractTransferContext db = new ContractTransferContext();

        // GET: ServiceCenters
        public ActionResult Index()
        {
            return View(db.ServiceCenters.ToList());
        }

        // GET: ServiceCenters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceCenter serviceCenter = db.ServiceCenters.Find(id);
            if (serviceCenter == null)
            {
                return HttpNotFound();
            }
            return View(serviceCenter);
        }

        // GET: ServiceCenters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServiceCenters/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Address")] ServiceCenter serviceCenter)
        {
            if (ModelState.IsValid)
            {
                db.ServiceCenters.Add(serviceCenter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(serviceCenter);
        }

        // GET: ServiceCenters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceCenter serviceCenter = db.ServiceCenters.Find(id);
            if (serviceCenter == null)
            {
                return HttpNotFound();
            }
            return View(serviceCenter);
        }

        // POST: ServiceCenters/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Address")] ServiceCenter serviceCenter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serviceCenter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(serviceCenter);
        }

        // GET: ServiceCenters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceCenter serviceCenter = db.ServiceCenters.Find(id);
            if (serviceCenter == null)
            {
                return HttpNotFound();
            }
            return View(serviceCenter);
        }

        // POST: ServiceCenters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceCenter serviceCenter = db.ServiceCenters.Find(id);
            db.ServiceCenters.Remove(serviceCenter);
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
