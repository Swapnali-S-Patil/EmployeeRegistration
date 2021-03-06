﻿using System;
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

        [HandleError]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpolyeeID,FirstName,LastName,DOB,Gender,MarritalStatus,CountryID,StateID,Address,Hobbies")] tblEmployee tblEmployee)
        {
            try
            {
                if (ModelState.IsValidField("DOB") && (DateTime.Now < tblEmployee.DOB))
                {
                    ModelState.AddModelError("DOB", "Please enter date in the past");
                }

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
            catch (Exception ex)
            {
                ErrorLog ObjError = new ErrorLog();
                ObjError.Log(ex.Message);
                return View();
            }

        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            try
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


                ViewBag.Date = Convert.ToDateTime(tblEmployee.DOB).ToString("yyyy-MM-dd");

                ViewBag.CountryID = new SelectList(db.tblCountries, "CountryID", "CountryName", tblEmployee.CountryID);
                ViewBag.StateID = new SelectList(db.tblStates, "StateID", "StateName", tblEmployee.StateID);
                return View(tblEmployee);
            }
            catch (Exception ex)
            {
                ErrorLog ObjError = new ErrorLog();
                ObjError.Log(ex.Message);
                return View();
            }
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HandleError]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpolyeeID,FirstName,LastName,DOB,Gender,MarritalStatus,CountryID,StateID,Address,Hobbies")] tblEmployee tblEmployee)
        {
            try
            {

                if (ModelState.IsValidField("DOB") && (DateTime.Now < tblEmployee.DOB))
                {
                    ModelState.AddModelError("DOB", "Please enter a date in the past");
                }

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
            catch (Exception ex)
            {
                ErrorLog ObjError = new ErrorLog();
                ObjError.Log(ex.Message);
                return View();
            }
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            try
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
            catch (Exception ex)
            {
                ErrorLog ObjError = new ErrorLog();
                ObjError.Log(ex.Message);
                return View();
            }
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                tblEmployee tblEmployee = db.tblEmployees.Find(id);
                db.tblEmployees.Remove(tblEmployee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ErrorLog ObjError = new ErrorLog();
                ObjError.Log(ex.Message);
                return View();
            }
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
