using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeeRegistration.Models;

namespace EmployeeRegistration.Controllers
{
    public class StateController : Controller
    {
        private DbEmployeeEntities5 db = new DbEmployeeEntities5();

        // GET: State
        public ActionResult Index()
        {
            var tblStates = db.tblStates.Include(t => t.tblCountry);
            return View(tblStates.ToList());
        }

        // GET: State/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblState tblState = db.tblStates.Find(id);
            if (tblState == null)
            {
                return HttpNotFound();
            }
            return View(tblState);
        }

        // GET: State/Create
        public ActionResult Create()
        {
            ViewBag.CountryID = new SelectList(db.tblCountries, "CountryID", "CountryName");
            return View();
        }

        // POST: State/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StateID,CountryID,StateName")] tblState tblState)
        {
            if (ModelState.IsValid)
            {
                db.tblStates.Add(tblState);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CountryID = new SelectList(db.tblCountries, "CountryID", "CountryName", tblState.CountryID);
            return View(tblState);
        }

        // GET: State/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblState tblState = db.tblStates.Find(id);
            if (tblState == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryID = new SelectList(db.tblCountries, "CountryID", "CountryName", tblState.CountryID);
            return View(tblState);
        }

        // POST: State/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StateID,CountryID,StateName")] tblState tblState)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblState).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryID = new SelectList(db.tblCountries, "CountryID", "CountryName", tblState.CountryID);
            return View(tblState);
        }

        // GET: State/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblState tblState = db.tblStates.Find(id);
            if (tblState == null)
            {
                return HttpNotFound();
            }
            return View(tblState);
        }

        // POST: State/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblState tblState = db.tblStates.Find(id);
            db.tblStates.Remove(tblState);
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
