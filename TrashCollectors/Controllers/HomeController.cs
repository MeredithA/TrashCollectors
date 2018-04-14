using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollectors.Models;

namespace TrashCollectors.Controllers
{
    public class HomeController : Controller
    {
       [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

         public ActionResult Details()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            string userID = User.Identity.GetUserId();
            Customer customer = (from row in db.Customers where row.UserId == userID select row).FirstOrDefault();

            return View(customer);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Schedule trash pick ups right at your fingertips!";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Us";

            return View();
        }
    }
}