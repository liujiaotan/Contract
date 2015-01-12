using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Contract.Models;
using Webdiyer.WebControls.Mvc;

namespace Contract.Controllers
{
    public class EmployeesController : BaseController
    {
        private ContractTransferContext db = new ContractTransferContext();

        // GET: Employees
        [Authorize]
        public ActionResult Index(int? id, int? ServiceCenter, string RealName, string Mobile, int page = 1)
        {
            var employee = db.Employees.Include(c => c.ServiceCenter).Include(m => m.Roles).Where(m => m.IsDeleted == false && m.ID > 0);
            ViewBag.ServiceCenter = new SelectList(db.ServiceCenters, "ID", "Name", ServiceCenter);
            if (id != null)
                employee = employee.Where(m => m.ID == id);
            if (ServiceCenter != null)
                employee = employee.Where(m => m.ServiceCenterID == ServiceCenter);
            if (!string.IsNullOrWhiteSpace(RealName))
                employee = employee.Where(m => m.RealName.Contains(RealName));
            if (!string.IsNullOrWhiteSpace(Mobile))
                employee = employee.Where(m => m.Mobile.Contains(Mobile));
            return View(employee.OrderByDescending(m => m.ID).ToPagedList<Employee>(page, pageSize));
        }

        // GET: Employees/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.ServiceCenterID = new SelectList(db.ServiceCenters, "ID", "Name");
            ViewBag.Roles = new SelectList(db.Roles.Where(m => m.ID > 0), "ID", "Name");
            return View();
        }

        // POST: Employees/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "ID,ServiceCenterID,RealName,Sex,Mobile,QQ,E_Mail")] Employee employee, int? Roles)
        {
            if (ModelState.IsValid)
            {
                if (Roles != null && Roles > 0)
                {
                    var role = db.Roles.FirstOrDefault(m => m.ID == Roles);
                    if (role != null)
                    {
                        employee.Roles.Add(role);
                    }
                }
                employee.User = new User { UserName = employee.RealName, PassWord = "" };
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.ServiceCenterID = new SelectList(db.ServiceCenters, "ID", "Name", employee.ServiceCenterID);
            ViewBag.Roles = new SelectList(db.Roles.Where(m => m.ID > 0), "ID", "Name", employee.Roles.First().ID);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "ID,ServiceCenterID,RealName,Sex,Mobile,QQ,E_Mail,IsFreezed")] Employee employee, int? Roles)
        {
            if (ModelState.IsValid)
            {
                var currentEmployee = db.Employees.Find(employee.ID);
                currentEmployee.ServiceCenterID = employee.ServiceCenterID;
                currentEmployee.RealName = employee.RealName;
                currentEmployee.Sex = employee.Sex;
                currentEmployee.Mobile = employee.Mobile;
                currentEmployee.QQ = employee.QQ;
                currentEmployee.E_Mail = employee.E_Mail;
                currentEmployee.IsFreezed = employee.IsFreezed;
                currentEmployee.Roles.Clear();

                if (Roles != null && Roles > 0)
                {
                    var role = db.Roles.Find(Roles);
                    if (role != null)
                    {
                        currentEmployee.Roles.Add(role);
                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ServiceCenterID = new SelectList(db.ServiceCenters, "ID", "Name", employee.ServiceCenterID);
            ViewBag.Roles = new SelectList(db.Roles.Where(m => m.ID > 0), "ID", "Name", employee.Roles.First().ID);
            return View(employee);
        }

        // GET: Employees/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            employee.IsDeleted = true;
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
