using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TicketSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace TicketSystem.Controllers
{
    public class ResolvedTicketController : Controller
    {
        private ticketTrackerEntities db = new ticketTrackerEntities();

        // GET: ResolvedTicket
        public ActionResult Index()
        {
            //var tblTickets = db.tblTickets.Include(t => t.tblUser).Include(t => t.tlkpSeverityType);
            //return View(tblTickets.ToList());

            var tblTicket = db.tblTickets.SqlQuery("SELECT * FROM tblTicket WHERE blnResolved = 1");
            return View(tblTicket.ToList());

            //if (db.tblTickets.blnResolved)
            //var tblTickets = db.tblTickets.Find(bit);
            //var return ();
        }
        //public tblTicket Get(int id)
        //{
        //    var tblTicket = db.tblTickets.SqlQuery("SELECT * FROM tblTicket WHERE blnResolved = 1");
        //    return View(tblTicket.ToList());
        //}

        // GET: ResolvedTicket/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTicket tblTicket = db.tblTickets.Find(id);
            if (tblTicket == null)
            {
                return HttpNotFound();
            }
            return View(tblTicket);
        }

        // GET: ResolvedTicket/Create
        public ActionResult Create()
        {
            ViewBag.idsUserCreate = new SelectList(db.tblUsers, "idsUser", "txtUserName");
            ViewBag.idsSeverityType = new SelectList(db.tlkpSeverityTypes, "idsSeverityType", "txtSeverityType");
            return View();
        }

        // POST: ResolvedTicket/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idsTicket,idsSeverityType,dtmCreate,idsUserCreate,txtIssue,blnResolved")] tblTicket tblTicket)
        {
            if (ModelState.IsValid)
            {
                db.tblTickets.Add(tblTicket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idsUserCreate = new SelectList(db.tblUsers, "idsUser", "txtUserName", tblTicket.idsUserCreate);
            ViewBag.idsSeverityType = new SelectList(db.tlkpSeverityTypes, "idsSeverityType", "txtSeverityType", tblTicket.idsSeverityType);
            return View(tblTicket);
        }

        // GET: ResolvedTicket/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTicket tblTicket = db.tblTickets.Find(id);
            if (tblTicket == null)
            {
                return HttpNotFound();
            }
            ViewBag.idsUserCreate = new SelectList(db.tblUsers, "idsUser", "txtUserName", tblTicket.idsUserCreate);
            ViewBag.idsSeverityType = new SelectList(db.tlkpSeverityTypes, "idsSeverityType", "txtSeverityType", tblTicket.idsSeverityType);
            return View(tblTicket);
        }

        // POST: ResolvedTicket/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idsTicket,idsSeverityType,dtmCreate,idsUserCreate,txtIssue,blnResolved")] tblTicket tblTicket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblTicket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idsUserCreate = new SelectList(db.tblUsers, "idsUser", "txtUserName", tblTicket.idsUserCreate);
            ViewBag.idsSeverityType = new SelectList(db.tlkpSeverityTypes, "idsSeverityType", "txtSeverityType", tblTicket.idsSeverityType);
            return View(tblTicket);
        }

        // GET: ResolvedTicket/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTicket tblTicket = db.tblTickets.Find(id);
            if (tblTicket == null)
            {
                return HttpNotFound();
            }
            return View(tblTicket);
        }

        // POST: ResolvedTicket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblTicket tblTicket = db.tblTickets.Find(id);
            db.tblTickets.Remove(tblTicket);
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
        //public ActionResult Sort()
        //{
        //    var tblTicket = db.tblTickets.SqlQuery("SELECT * FROM tblTicket WHERE blnResolved = 1");
        //    return View(tblTicket.ToList());
        //} 
    }
}
