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
    public class tlkpSeverityTypesController : Controller
    {
        private ticketTrackerEntities db = new ticketTrackerEntities();

        // GET: tlkpSeverityTypes
        public ActionResult Index()
        {
            return View(db.tlkpSeverityTypes.ToList());
        }

        // GET: tlkpSeverityTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tlkpSeverityType tlkpSeverityType = db.tlkpSeverityTypes.Find(id);
            if (tlkpSeverityType == null)
            {
                return HttpNotFound();
            }
            return View(tlkpSeverityType);
        }

        // GET: tlkpSeverityTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tlkpSeverityTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idsSeverityType,txtSeverityType,dtmCreate")] tlkpSeverityType tlkpSeverityType)
        {
            if (ModelState.IsValid)
            {
                db.tlkpSeverityTypes.Add(tlkpSeverityType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tlkpSeverityType);
        }

        // GET: tlkpSeverityTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tlkpSeverityType tlkpSeverityType = db.tlkpSeverityTypes.Find(id);
            if (tlkpSeverityType == null)
            {
                return HttpNotFound();
            }
            return View(tlkpSeverityType);
        }

        // POST: tlkpSeverityTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idsSeverityType,txtSeverityType,dtmCreate")] tlkpSeverityType tlkpSeverityType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tlkpSeverityType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tlkpSeverityType);
        }

        // GET: tlkpSeverityTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tlkpSeverityType tlkpSeverityType = db.tlkpSeverityTypes.Find(id);
            if (tlkpSeverityType == null)
            {
                return HttpNotFound();
            }
            return View(tlkpSeverityType);
        }

        // POST: tlkpSeverityTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tlkpSeverityType tlkpSeverityType = db.tlkpSeverityTypes.Find(id);
            db.tlkpSeverityTypes.Remove(tlkpSeverityType);
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
