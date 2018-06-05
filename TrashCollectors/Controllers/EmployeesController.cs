using Microsoft.AspNet.Identity;
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
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employees
        public ActionResult Index()
        {
            string userid = User.Identity.GetUserId();
            List<Employee> employees = (from row in db.Employees where row.UserId == userid select row).ToList();
            if (employees.Count == 0)
            {
                return RedirectToAction("Create");
            }
            return View(employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserId,FirstName,LastName,ZipCode")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.UserId = User.Identity.GetUserId();
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index", "Employees");
            }
            return View(employee);
        }

        public ActionResult Work()
        {
            string userID = User.Identity.GetUserId();
            WorkViewModel model = new WorkViewModel();
            model.Employee = (from row in db.Employees where row.UserId == userID select row).FirstOrDefault();
            string today = DateTime.Now.DayOfWeek.ToString().ToLower();
            List<Customer> customers = (from row in db.Customers where row.ZipCode == model.Employee.ZipCode && row.ScheduledPickUpDay.ToLower() == today select row).ToList();
            model.Customers = new List<Customer>();
            foreach(Customer customer in customers)
            {
                if (CheckIfCustomerActive(customer))
                {
                    model.Customers.Add(customer);
                }
            }
            
            return View(model);
        }

        private bool CheckIfCustomerActive(Customer customer)
        {
            SuspendService suspension = (from x in db.SuspendServices where x.CustomerId == customer.ID select x).FirstOrDefault();
            if (suspension != null)
            {
                if(suspension.StartDate != null && suspension.StartDate.Value.Ticks <= DateTime.Now.Ticks)
                {
                    if(suspension.EndDate == null || suspension.EndDate.Value.Ticks > DateTime.Now.Ticks)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        public ActionResult PickUp(int? id)
        {
            BilingAccount BillingAccount;
            try
            {
                BillingAccount = (from row in db.BillingAccounts where row.CustomerId == (int)id select row).First();
                BillingAccount.Balance += 20;
                BillingAccount.LastChargeDate = "Today";
            }
            catch
            {
                BillingAccount = new BilingAccount();
                BillingAccount.CustomerId = (int)id;
                BillingAccount.Balance = 20;
                BillingAccount.LastChargeDate = "Today";
                db.BillingAccounts.Add(BillingAccount);
            }
            db.SaveChanges();
            return View("PickedUp");

        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", employee.UserId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserId,FirstName,LastName,ZipCode")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", employee.UserId);
            return View("Index");
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
