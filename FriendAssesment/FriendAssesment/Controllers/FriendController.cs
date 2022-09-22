﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FriendAssesment;

namespace FriendAssesment.Controllers
{
    public class FriendController : Controller
    {
        private Freshers_Training2022Entities db = new Freshers_Training2022Entities();
        public ActionResult Index()
        {
            return View(db.karthiks_friend.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FriendID,FriendName,Place")] karthiks_friend karthiks_friend)
        {
            if (ModelState.IsValid)
            {
                db.karthiks_friend.Add(karthiks_friend);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(karthiks_friend);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            karthiks_friend karthiks_friend = db.karthiks_friend.Find(id);
            if (karthiks_friend == null)
            {
                return HttpNotFound();
            }
            return View(karthiks_friend);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FriendID,FriendName,Place")] karthiks_friend karthiks_friend)
        {
            if (ModelState.IsValid)
            {
                db.Entry(karthiks_friend).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(karthiks_friend);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            karthiks_friend karthiks_friend = db.karthiks_friend.Find(id);
            if (karthiks_friend == null)
            {
                return HttpNotFound();
            }
            return View(karthiks_friend);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            karthiks_friend karthiks_friend = db.karthiks_friend.Find(id);
            db.karthiks_friend.Remove(karthiks_friend);
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
