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
    public class tlkpUserTypesController : Controller
    {
        private ticketTrackerEntities db = new ticketTrackerEntities();

        // GET: tlkpUserTypes
        public ActionResult Index()
        {
            return View(db.tlkpUserTypes.ToList());
        }

        // GET: tlkpUserTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tlkpUserType tlkpUserType = db.tlkpUserTypes.Find(id);
            if (tlkpUserType == null)
            {
                return HttpNotFound();
            }
            return View(tlkpUserType);
        }

        // GET: tlkpUserTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tlkpUserTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idsUserType,txtUserType,dtmCreate")] tlkpUserType tlkpUserType)
        {
            if (ModelState.IsValid)
            {
                db.tlkpUserTypes.Add(tlkpUserType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tlkpUserType);
        }

        // GET: tlkpUserTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tlkpUserType tlkpUserType = db.tlkpUserTypes.Find(id);
            if (tlkpUserType == null)
            {
                return HttpNotFound();
            }
            return View(tlkpUserType);
        }

        // POST: tlkpUserTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idsUserType,txtUserType,dtmCreate")] tlkpUserType tlkpUserType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tlkpUserType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tlkpUserType);
        }

        // GET: tlkpUserTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tlkpUserType tlkpUserType = db.tlkpUserTypes.Find(id);
            if (tlkpUserType == null)
            {
                return HttpNotFound();
            }
            return View(tlkpUserType);
        }

        // POST: tlkpUserTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tlkpUserType tlkpUserType = db.tlkpUserTypes.Find(id);
            db.tlkpUserTypes.Remove(tlkpUserType);
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
