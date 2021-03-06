﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Contract.Models;
using System.Data.Entity.Validation;
using Webdiyer.WebControls.Mvc;

namespace Contract.Controllers
{
    public class TenanciesController : BaseController
    {
        private ContractTransferContext db = new ContractTransferContext();

        // GET: Tenancies
        [Authorize]
        public ActionResult Index(int? id,  string Number,string Company, int page = 1)
        {
            var tenancies = db.Tenancies.Include(t => t.Company).Include(t => t.Process).Include(t => t.ServiceCenter).Include("TenancyCheckLogs.Task").Include("TenancyCheckLogs.Employee.Roles").Where(m => m.IsDelete == false);
            if (!string.IsNullOrWhiteSpace(Number))
                tenancies = tenancies.Where(m => m.Number.Contains(Number));
            if (Company != null)
                tenancies = tenancies.Where(m => m.Company.Name.Contains(Company));
            return View(tenancies.OrderByDescending(m => m.ID).ToPagedList<Tenancy>(page, pageSize));
        }

        // GET: Tenancies/Details/5
        [Authorize]
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
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.Rooms = new SelectList(db.Rooms, "ID", "Number");
            return View();
        }

        // POST: Tenancies/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "ID,CompanyID,Number,UnitCost,ServiceFee,HeatingFee,ElectricityRate,LeaseTerm")] Tenancy tenancy, string SelectRooms)
        {
            if (ModelState.IsValid)
            {
                tenancy.Process = db.Processes.FirstOrDefault(m=>m.Name == "Tenancy");
                var me = db.Employees.Find(int.Parse(this.User.Identity.Name));
                var serviceCenter = db.ServiceCenters.FirstOrDefault(m => m.ID == me.ServiceCenterID);
                tenancy.ServiceCenterID = me.ServiceCenterID;
                var lastTenancy = db.Tenancies.OrderByDescending(m => m.Number).FirstOrDefault(m => m.ServiceCenterID == me.ServiceCenterID);
                var number = "";
                if(lastTenancy!=null)
                {
                    number = lastTenancy.Number;
                }
                var serialNumber = "";
                if(number == "" || int.Parse(number.Substring(number.Length-5,2))!=DateTime.Now.Month)
                   serialNumber = "001";
                else
                   serialNumber = (int.Parse(number.Substring(number.Length - 3)) + 1).ToString().PadLeft(3, '0');
                tenancy.Number = serviceCenter.Alias + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0') + serialNumber;
                var rooms = SelectRooms.Split(',');
                foreach(var room in rooms)
                {
                    tenancy.Rooms.Add(db.Rooms.Find(int.Parse(room)));
                }
                db.Tenancies.Add(tenancy);
                db.SaveChanges();
                var task = db.Tasks.SingleOrDefault(m => m.Process.Name == "Tenancy" && m.NoteType == "Start");
                if (task != null)
                {
                    db.TenancyCheckLogs.Add(new TenancyCheckLog { EmployeeID = this.UserID, TaskID = task.ID, TenancyID = tenancy.ID,Action="Create" });
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Rooms = new SelectList(db.Rooms, "ID", "Number");
            return View(tenancy);
        }

        // GET: Tenancies/Edit/5
        [Authorize]
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
            ViewBag.Rooms = new SelectList(db.Rooms, "ID", "Number");
            return View(tenancy);
        }

        // POST: Tenancies/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "ID,CompanyID,Number,UnitCost,ServiceFee,HeatingFee,ElectricityRate,LeaseTerm")] Tenancy tenancy,string SelectRooms)
        {
            if (ModelState.IsValid)
            {
                var currentTenancy = db.Tenancies.Find(tenancy.ID);
                currentTenancy.CompanyID = tenancy.CompanyID;
                currentTenancy.UnitCost = tenancy.UnitCost;
                currentTenancy.ServiceFee = tenancy.ServiceFee;
                currentTenancy.HeatingFee = tenancy.HeatingFee;
                currentTenancy.ElectricityRate = tenancy.ElectricityRate;
                currentTenancy.LeaseTerm = tenancy.LeaseTerm;
                currentTenancy.Rooms.Clear();
                var rooms = SelectRooms.Split(',');
                foreach (var room in rooms)
                {
                    currentTenancy.Rooms.Add(db.Rooms.Find(int.Parse(room)));
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "ID", "Name", tenancy.CompanyID);
            ViewBag.ProcessID = new SelectList(db.Processes, "ID", "Name", tenancy.ProcessID);
            ViewBag.ServiceCenterID = new SelectList(db.ServiceCenters, "ID", "Name", tenancy.ServiceCenterID);
            return View(tenancy);
        }

        // GET: Tenancies/Delete/5
        [Authorize]
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
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Tenancy tenancy = db.Tenancies.Find(id);
            tenancy.IsDelete = true;
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

        [Authorize]
        public ActionResult Submit(int? id)
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
            var lastLog = db.TenancyCheckLogs.OrderByDescending(m => m.ID).FirstOrDefault(m => m.TenancyID == id);
            var nextTask = db.Routes.SingleOrDefault(m=>m.FromTask == lastLog.TaskID);
            if (nextTask != null)
            {
                db.TenancyCheckLogs.Add(new TenancyCheckLog { EmployeeID = nextTask.Task1.Role.Employees.First().ID, TaskID = nextTask.ToTask, TenancyID = tenancy.ID, Action = "Submit" });
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpPost]
        public ActionResult Accept(int? pk,int? value)
        {
            if (pk == null || value == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var lastLog = db.TenancyCheckLogs.OrderByDescending(m=>m.ID).FirstOrDefault(m=>m.TenancyID == pk);
            if (lastLog == null)
            {
                return HttpNotFound();
            }
            if (lastLog.EmployeeID != this.UserID)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //db.TenancyCheckLogs.Add(new TenancyCheckLog { EmployeeID = this.UserID, TaskID = task.ID, TenancyID = tenancy.ID, Action = "Create" });
            //db.SaveChanges();
            return Json(new { });
        }

    }
}
