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
    public class RoomsController : BaseController
    {
        private ContractTransferContext db = new ContractTransferContext();

        // GET: Rooms
        [Authorize]
        public ActionResult Index(int? id, int? ServiceCenter, int? Category, string Number, int page = 1)
        {

            ViewBag.Category = new SelectList(db.RoomCategories, "ID", "Name", Category);
            ViewBag.ServiceCenter = new SelectList(db.ServiceCenters, "ID", "Name", ServiceCenter);
            var rooms = db.Rooms.Include(r => r.RoomCategory).Include(r => r.RoomState).Include(r => r.RoomType).Include(r => r.ServiceCenter);
            if (!string.IsNullOrWhiteSpace(Number))
                rooms = rooms.Where(m => m.Number.Contains(Number));
            if (ServiceCenter != null)
                rooms = rooms.Where(m => m.ServiceCenterID == ServiceCenter);
            if (Category != null)
                rooms = rooms.Where(m => m.Category == Category);
            return View(rooms.OrderByDescending(m => m.ID).ToPagedList<Room>(page, pageSize));
        }

        // GET: Rooms/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // GET: Rooms/Create
        [Authorize]
        public ActionResult Create(int? id)
        {

            ViewBag.ServiceCenter = db.ServiceCenters.FirstOrDefault(m => m.ID == id);
            ViewBag.Category = new SelectList(db.RoomCategories, "ID", "Name");
            ViewBag.State = new SelectList(db.RoomStates, "ID", "Name");
            ViewBag.Type = new SelectList(db.RoomTypes, "ID", "Name");
            ViewBag.ServiceCenterID = new SelectList(db.ServiceCenters, "ID", "Name");
            return View();
        }

        // POST: Rooms/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "ID,ServiceCenterID,Category,Type,Number,Space,Description")] Room room)
        {
            if (ModelState.IsValid)
            {
                room.State = 1;
                room.CreateDate = DateTime.Now;
                db.Rooms.Add(room);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = room.ServiceCenterID });
            }
            ViewBag.ServiceCenterID = room.ServiceCenterID;
            ViewBag.Category = new SelectList(db.RoomCategories, "ID", "Name", room.Category);
            ViewBag.State = new SelectList(db.RoomStates, "ID", "Name", room.State);
            ViewBag.Type = new SelectList(db.RoomTypes, "ID", "Name", room.Type);
            ViewBag.ServiceCenterID = new SelectList(db.ServiceCenters, "ID", "Name", room.ServiceCenterID);
            return View(room);
        }

        // GET: Rooms/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            ViewBag.Category = new SelectList(db.RoomCategories, "ID", "Name", room.Category);
            ViewBag.State = new SelectList(db.RoomStates, "ID", "Name", room.State);
            ViewBag.Type = new SelectList(db.RoomTypes, "ID", "Name", room.Type);
            ViewBag.ServiceCenterID = new SelectList(db.ServiceCenters, "ID", "Name", room.ServiceCenterID);
            return View(room);
        }

        // POST: Rooms/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "ID,ServiceCenterID,Category,Type,State,Floor,Number,Space,Description,CreateDate")] Room room)
        {
            if (ModelState.IsValid)
            {
                room.State = 1;
                room.CreateDate = DateTime.Now;
                db.Entry(room).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category = new SelectList(db.RoomCategories, "ID", "Name", room.Category);
            ViewBag.State = new SelectList(db.RoomStates, "ID", "Name", room.State);
            ViewBag.Type = new SelectList(db.RoomTypes, "ID", "Name", room.Type);
            ViewBag.ServiceCenterID = new SelectList(db.ServiceCenters, "ID", "Name", room.ServiceCenterID);
            return View(room);
        }

        // GET: Rooms/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Room room = db.Rooms.Find(id);
            db.Rooms.Remove(room);
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
