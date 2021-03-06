﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollectors.Models;

namespace TrashCollectors.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: Customers
        public ActionResult Index()
        {
            string userid = User.Identity.GetUserId();
            List<Customer> customers = (from row in db.Customers where row.UserId == userid select row).ToList();
            if (customers.Count == 0)
            {
                return RedirectToAction("Create");
            }
            return View(customers.ToList());
        }

        // GET: Customers/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Customer customer = db.Customers.Find(id);
        //    if (customer == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(customer);
        //}

        // GET: Customers/Create
        public ActionResult Create()
        {
  //          ViewBag.UserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserId,FirstName,LastName,StreetAddress,City,State,ZipCode,ScheduledPickUpDay")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.UserId = User.Identity.GetUserId();
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index", "Customers"); //"customers added per mosh
            }

            // ViewBag.UserId = new SelectList(db.Users, "Id", "Email", customer.UserId);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", customer.UserId);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserId,FirstName,LastName,Address,StreetAdress,City,State,ZipCode,ScheduledPickUpDay")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", customer.UserId);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult ViewBalance()
        {
            string userID = User.Identity.GetUserId();
            Customer currentCustomer = (from row in db.Customers where row.UserId == userID select row).FirstOrDefault();
            BilingAccount model = (from row in db.BillingAccounts where row.CustomerId == currentCustomer.ID select row).FirstOrDefault();
            return View(model);
        }


        public ActionResult SuspendService(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuspendService suspendService = (from row in db.SuspendServices where row.CustomerId == id select row).FirstOrDefault();
            if (suspendService == null)
            {
                suspendService = new SuspendService();
                suspendService.CustomerId =(int)id;
            }
            //      we need a VM for the suspension form...
            return View(suspendService);
        }

        [HttpPost]
        public ActionResult SuspendService(SuspendService model)
        {
            string userID = User.Identity.GetUserId();
            Customer currentCustomer = (from row in db.Customers where row.UserId == userID select row).FirstOrDefault();
            SuspendService suspendService = (from row in db.SuspendServices where row.CustomerId == currentCustomer.ID select row).FirstOrDefault();
            if (suspendService == null)
            {
                db.SuspendServices.Add(model);
            }
            else
            {
                suspendService.StartDate = model.StartDate;
                suspendService.EndDate = model.EndDate;
            }
            db.SaveChanges();
            return RedirectToAction ("index");
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
