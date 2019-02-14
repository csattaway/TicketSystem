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
    public class tblUsersController : Controller
    {
        private ticketTrackerEntities db = new ticketTrackerEntities();
        private tblUser objectTblUser = new tblUser();

        // GET: tblUsers
        public ActionResult Index()
        {
            var tblUsers = db.tblUsers.Include(t => t.tlkpUserType);
            return View(tblUsers.ToList());
        }

        // GET: tblUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUser tblUser = db.tblUsers.Find(id);
            if (tblUser == null)
            {
                return HttpNotFound();
            }
            return View(tblUser);
        }

        // GET: tblUsers/Create
        public ActionResult Create()
        {
            ViewBag.idsUserType = new SelectList(db.tlkpUserTypes, "idsUserType", "txtUserType");
            //ViewBag.dtmCreate = DateTime.Now;
            
            return View();
        }

        // POST: tblUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idsUser,txtUserName,idsUserType")]tblUser tblUser)
        {
            if (ModelState.IsValid)
            {
                db.tblUsers.Add(tblUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        //            public ActionResult Create([Bind(Include = "idsUser,txtUserName,idsUserType")]tblUser objectTblUser)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //db.tblUsers.Add(tblUser);
        //        //db.SaveChanges();
        //        objectTblUser.dtmCreate = DateTime.Now;
        //        objectTblUser.idsUserType = 2;
        //        objectTblUser.idsUser = 0;
        //        objectTblUser.txtUserName = "Jeff";
        //        objectTblUser.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
            ViewBag.idsUserType = new SelectList(db.tlkpUserTypes, "idsUserType", "txtUserType", tblUser.idsUserType);
            return View(tblUser);
        }

        // GET: tblUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUser tblUser = db.tblUsers.Find(id);
            if (tblUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.idsUserType = new SelectList(db.tlkpUserTypes, "idsUserType", "txtUserType", tblUser.idsUserType);
            return View(tblUser);
        }

        // POST: tblUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idsUser,txtUserName,idsUserType,dtmCreate")] tblUser tblUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idsUserType = new SelectList(db.tlkpUserTypes, "idsUserType", "txtUserType", tblUser.idsUserType);
            return View(tblUser);
        }

        // GET: tblUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUser tblUser = db.tblUsers.Find(id);
            if (tblUser == null)
            {
                return HttpNotFound();
            }
            return View(tblUser);
        }

        // POST: tblUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblUser tblUser = db.tblUsers.Find(id);
            db.tblUsers.Remove(tblUser);
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
