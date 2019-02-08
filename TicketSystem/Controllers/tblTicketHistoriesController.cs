using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TicketSystem.Models;

namespace TicketSystem.Controllers
{
    public class tblTicketHistoriesController : Controller
    {
        private ticketTrackerEntities db = new ticketTrackerEntities();

        // GET: tblTicketHistories
        public ActionResult Index()
        {
            var tblTicketHistories = db.tblTicketHistories.Include(t => t.tblTicket).Include(t => t.tblUser);
            return View(tblTicketHistories.ToList());
        }

        // GET: tblTicketHistories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTicketHistory tblTicketHistory = db.tblTicketHistories.Find(id);
            if (tblTicketHistory == null)
            {
                return HttpNotFound();
            }
            return View(tblTicketHistory);
        }

        // GET: tblTicketHistories/Create
        public ActionResult Create()
        {
            ViewBag.idsTicket = new SelectList(db.tblTickets, "idsTicket", "txtIssue");
            ViewBag.idsUser = new SelectList(db.tblUsers, "idsUser", "txtUserName");
            return View();
        }

        // POST: tblTicketHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idsTicketHistory,dtmEdit,idsUser,blnResolved,idsTicket")] tblTicketHistory tblTicketHistory)
        {
            if (ModelState.IsValid)
            {
                db.tblTicketHistories.Add(tblTicketHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idsTicket = new SelectList(db.tblTickets, "idsTicket", "txtIssue", tblTicketHistory.idsTicket);
            ViewBag.idsUser = new SelectList(db.tblUsers, "idsUser", "txtUserName", tblTicketHistory.idsUser);
            return View(tblTicketHistory);
        }

        // GET: tblTicketHistories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTicketHistory tblTicketHistory = db.tblTicketHistories.Find(id);
            if (tblTicketHistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.idsTicket = new SelectList(db.tblTickets, "idsTicket", "txtIssue", tblTicketHistory.idsTicket);
            ViewBag.idsUser = new SelectList(db.tblUsers, "idsUser", "txtUserName", tblTicketHistory.idsUser);
            return View(tblTicketHistory);
        }

        // POST: tblTicketHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idsTicketHistory,dtmEdit,idsUser,blnResolved,idsTicket")] tblTicketHistory tblTicketHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblTicketHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idsTicket = new SelectList(db.tblTickets, "idsTicket", "txtIssue", tblTicketHistory.idsTicket);
            ViewBag.idsUser = new SelectList(db.tblUsers, "idsUser", "txtUserName", tblTicketHistory.idsUser);
            return View(tblTicketHistory);
        }

        // GET: tblTicketHistories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTicketHistory tblTicketHistory = db.tblTicketHistories.Find(id);
            if (tblTicketHistory == null)
            {
                return HttpNotFound();
            }
            return View(tblTicketHistory);
        }

        // POST: tblTicketHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblTicketHistory tblTicketHistory = db.tblTicketHistories.Find(id);
            db.tblTicketHistories.Remove(tblTicketHistory);
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
