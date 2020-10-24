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
    public class EmployeesController : Controller
    {
        private DbEmployeeEntities5 db = new DbEmployeeEntities5();

        // GET: Employees
        public ActionResult Index()
        {
            var tblEmployees = db.tblEmployees.Include(t => t.tblCountry).Include(t => t.tblState);
            return View(tblEmployees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmployee tblEmployee = db.tblEmployees.Find(id);
            if (tblEmployee == null)
            {
                return HttpNotFound();
            }
            return View(tblEmployee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.CountryID = new SelectList(db.tblCountries, "CountryID", "CountryName");
            ViewBag.StateID = new SelectList(db.tblStates, "StateID", "StateName");
            
            

            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpolyeeID,FirstName,LastName,DOB,Gender,MarritalStatus,CountryID,StateID,Address,Hobbies")] tblEmployee tblEmployee)
        {
            if (ModelState.IsValid)
            {
                db.tblEmployees.Add(tblEmployee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CountryID = new SelectList(db.tblCountries, "CountryID", "CountryName", tblEmployee.CountryID);
            ViewBag.StateID = new SelectList(db.tblStates, "StateID", "StateName", tblEmployee.StateID);
            return View(tblEmployee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmployee tblEmployee = db.tblEmployees.Find(id);
            if (tblEmployee == null)
            {
                return HttpNotFound();
            }
            //  (tblEmployee.DOB)=Convert.ToDateTime(Convert.ToDateTime(tblEmployee.DOB).ToString("yyyy-mm-yyyy"));

           
            ViewBag.Date =Convert.ToDateTime(tblEmployee.DOB).ToString("yyyy-MM-dd");

            ViewBag.CountryID = new SelectList(db.tblCountries, "CountryID", "CountryName", tblEmployee.CountryID);
            ViewBag.StateID = new SelectList(db.tblStates, "StateID", "StateName", tblEmployee.StateID);
            return View(tblEmployee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpolyeeID,FirstName,LastName,DOB,Gender,MarritalStatus,CountryID,StateID,Address,Hobbies")] tblEmployee tblEmployee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblEmployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryID = new SelectList(db.tblCountries, "CountryID", "CountryName", tblEmployee.CountryID);
            ViewBag.StateID = new SelectList(db.tblStates, "StateID", "StateName", tblEmployee.StateID);
            return View(tblEmployee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmployee tblEmployee = db.tblEmployees.Find(id);
            if (tblEmployee == null)
            {
                return HttpNotFound();
            }
            return View(tblEmployee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblEmployee tblEmployee = db.tblEmployees.Find(id);
            db.tblEmployees.Remove(tblEmployee);
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
