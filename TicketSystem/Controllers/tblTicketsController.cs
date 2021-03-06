﻿using System;
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
    public class tblTicketsController : Controller
    {
        private ticketTrackerEntities db = new ticketTrackerEntities();
        private tblUser objectTblUser = new tblUser();

        // GET: tblTickets

        //[Authorize(db.tblTickets.SqlQuery("SELECT idsUser FROM tblUser WHERE idsUserType = 1"))]
        public ActionResult Index()
        {
            //var tblTickets = db.tblTickets.Include(t => t.tblUser).Include(t => t.tlkpSeverityType);
            //return View(tblTickets.ToList());
                var tblTicket = db.tblTickets.SqlQuery("SELECT * FROM tblTicket WHERE blnResolved = 0");
            
                return View(tblTicket.ToList()); 
        }

        // GET: tblTickets/Details/5
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

        // GET: tblTickets/Create
        public ActionResult Create()
        {
            ViewBag.idsUserCreate = new SelectList(db.tblUsers, "idsUser", "txtUserName");
            ViewBag.idsSeverityType = new SelectList(db.tlkpSeverityTypes, "idsSeverityType", "txtSeverityType");
            ViewBag.dtmCreate = DateTime.Now.ToShortDateString();
            return View();
        }

        // POST: tblTickets/Create
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
            ViewBag.dtmCreate = DateTime.Now.ToShortDateString();
            return View(tblTicket);
        }

        // GET: tblTickets/Edit/5
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

        // POST: tblTickets/Edit/5
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

        // GET: tblTickets/Delete/5
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

        // POST: tblTickets/Delete/5
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
        public ActionResult criticalSeverity()
        {
            var CriticalTickets = db.tblTickets.SqlQuery("SELECT * FROM tblTicket WHERE idsSeverityType = 2 AND blnResolved = 0;");
            return View(CriticalTickets.ToList());
        }
        public ActionResult moderateSeverity()
        {
            var Moderate = db.tblTickets.SqlQuery("SELECT * FROM tblTicket WHERE idsSeverityType = 1 AND blnResolved = 0;");
            return View(Moderate.ToList());
        }
        public ActionResult mostRecent()
        {
            var mostRecent = db.tblTickets.SqlQuery("SELECT * FROM tblTicket WHERE blnResolved = 0 ORDER BY dtmCreate desc;");
            return View(mostRecent.ToList());
        }
        public ActionResult oldestFirst()
        {
            var oldestFirst = db.tblTickets.SqlQuery("SELECT * FROM tblTicket WHERE blnResolved = 0 ORDER BY dtmCreate asc;");
            return View(oldestFirst.ToList());
        }

        public ActionResult Sort()
        {
            var tblTicket = db.tblTickets.SqlQuery("SELECT * FROM tblTicket WHERE blnResolved = 0 ORDER BY idsSeverityType ASC;");
            return View(tblTicket.ToList());
        }

    }
}
