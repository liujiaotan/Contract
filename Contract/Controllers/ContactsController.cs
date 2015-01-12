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
    public class ContactsController : BaseController
    {
        private ContractTransferContext db = new ContractTransferContext();

        // GET: Contacts
        [Authorize]
        public ActionResult Index(int? id, string Name, string RealName, string Line, int page = 1)
        {

            var contacts = db.Contacts.Include(c => c.Company); ;
            if (id != null)
                contacts = contacts.Where(m => m.CompanyID == id);
            if (!string.IsNullOrWhiteSpace(Name))
                contacts = contacts.Where(m => m.Company.Name.Contains(Name));
            if (!string.IsNullOrWhiteSpace(RealName))
                contacts = contacts.Where(m => m.RealName.Contains(RealName));
            if (!string.IsNullOrWhiteSpace(Line))
                contacts = contacts.Where(m => m.Line.Contains(Line));
            return View(contacts.OrderByDescending(m => m.ID).ToPagedList<Contact>(page, pageSize));
        }

        // GET: Contacts/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // GET: Contacts/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.CompanyID = new SelectList(db.Companies, "ID", "Name");
            return View();
        }

        // POST: Contacts/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "ID,CompanyID,RealName,Sex,Line,Mobile,Position,QQ,E_Mail,MSN,CreateDate")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyID = new SelectList(db.Companies, "ID", "Name", contact.CompanyID);
            return View(contact);
        }

        // GET: Contacts/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "ID", "Name", contact.CompanyID);
            return View(contact);
        }

        // POST: Contacts/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "ID,CompanyID,RealName,Sex,Line,Mobile,Position,QQ,E_Mail,MSN,CreateDate")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "ID", "Name", contact.CompanyID);
            return View(contact);
        }

        // GET: Contacts/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact contact = db.Contacts.Find(id);
            db.Contacts.Remove(contact);
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
