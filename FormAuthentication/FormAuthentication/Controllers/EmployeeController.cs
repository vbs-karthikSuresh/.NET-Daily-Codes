using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FormAuthentication;

namespace FormAuthentication.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private Freshers_Training2022Entities db = new Freshers_Training2022Entities();

        // GET: Employee
        public ActionResult Index()
        {
            var form_Employee = db.Form_Employee.Include(f => f.Form_Department);
            return View(form_Employee.ToList());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Form_Employee form_Employee = db.Form_Employee.Find(id);
            if (form_Employee == null)
            {
                return HttpNotFound();
            }
            return View(form_Employee);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Form_Department, "Id", "DepartmentName");
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Gender,Age,Position,Office,HireDate,Salary,DepartmentId")] Form_Employee form_Employee)
        {
            if (ModelState.IsValid)
            {
                db.Form_Employee.Add(form_Employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.Form_Department, "Id", "DepartmentName", form_Employee.DepartmentId);
            return View(form_Employee);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Form_Employee form_Employee = db.Form_Employee.Find(id);
            if (form_Employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Form_Department, "Id", "DepartmentName", form_Employee.DepartmentId);
            return View(form_Employee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Gender,Age,Position,Office,HireDate,Salary,DepartmentId")] Form_Employee form_Employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(form_Employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Form_Department, "Id", "DepartmentName", form_Employee.DepartmentId);
            return View(form_Employee);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Form_Employee form_Employee = db.Form_Employee.Find(id);
            if (form_Employee == null)
            {
                return HttpNotFound();
            }
            return View(form_Employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Form_Employee form_Employee = db.Form_Employee.Find(id);
            db.Form_Employee.Remove(form_Employee);
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
