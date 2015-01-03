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
    public class TenanciesController : Controller
    {
        private ContractTransferContext db = new ContractTransferContext();

        // GET: Tenancies
        public ActionResult Index()
        {
            var tenancies = db.Tenancies.Include(t => t.Company).Include(t => t.Process).Include(t => t.ServiceCenter);
            return View(tenancies.ToList());
        }

        // GET: Tenancies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tenancy tenancy = db.Tenancies.Find(id);
            if (tenancy == null)
            {
                return HttpNotFound();
            }
            return View(tenancy);
        }

        // GET: Tenancies/Create
        public ActionResult Create()
        {
            ViewBag.CompanyID = new SelectList(db.Companies, "ID", "Name");
            ViewBag.ProcessID = new SelectList(db.Processes, "ID", "Name");
            ViewBag.ServiceCenterID = new SelectList(db.ServiceCenters, "ID", "Name");
            return View();
        }

        // POST: Tenancies/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ServiceCenterID,ProcessID,CompanyID,Number,UnitCost,ServiceFee,HeatingFee,ElectricityRate,LeaseTerm,EffectDate")] Tenancy tenancy)
        {
            if (ModelState.IsValid)
            {
                db.Tenancies.Add(tenancy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyID = new SelectList(db.Companies, "ID", "Name", tenancy.CompanyID);
            ViewBag.ProcessID = new SelectList(db.Processes, "ID", "Name", tenancy.ProcessID);
            ViewBag.ServiceCenterID = new SelectList(db.ServiceCenters, "ID", "Name", tenancy.ServiceCenterID);
            return View(tenancy);
        }

        // GET: Tenancies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tenancy tenancy = db.Tenancies.Find(id);
            if (tenancy == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "ID", "Name", tenancy.CompanyID);
            ViewBag.ProcessID = new SelectList(db.Processes, "ID", "Name", tenancy.ProcessID);
            ViewBag.ServiceCenterID = new SelectList(db.ServiceCenters, "ID", "Name", tenancy.ServiceCenterID);
            return View(tenancy);
        }

        // POST: Tenancies/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ServiceCenterID,ProcessID,CompanyID,Number,UnitCost,ServiceFee,HeatingFee,ElectricityRate,LeaseTerm,EffectDate")] Tenancy tenancy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tenancy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "ID", "Name", tenancy.CompanyID);
            ViewBag.ProcessID = new SelectList(db.Processes, "ID", "Name", tenancy.ProcessID);
            ViewBag.ServiceCenterID = new SelectList(db.ServiceCenters, "ID", "Name", tenancy.ServiceCenterID);
            return View(tenancy);
        }

        // GET: Tenancies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tenancy tenancy = db.Tenancies.Find(id);
            if (tenancy == null)
            {
                return HttpNotFound();
            }
            return View(tenancy);
        }

        // POST: Tenancies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tenancy tenancy = db.Tenancies.Find(id);
            db.Tenancies.Remove(tenancy);
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
