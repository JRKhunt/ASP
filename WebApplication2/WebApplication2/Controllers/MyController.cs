using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class MyController : Controller
    {
        // GET: My
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Pricing()
        {
            return View();
        }
        public ActionResult Student_data()
        {
            List<My> list = new List<My>()
            {
                new My()
                {
                    id = 1,
                    fname = "khunt",
                    lname = "jay",
                    city = "rajkot",
                    age = 21
                },
                new My()
                {
                    id = 2,
                    fname = "nathani",
                    lname = "darshil",
                    city = "rajkot",
                    age = 14
                },
            new My()
            {
                id = 3,
                fname = "kakadiya",
                lname = "parth",
                city = "rajkot",
                age = 31
            },
            new My()
            {
                id = 4,
                fname = "palwar",
                lname = "mahaveersinh",
                city = "rajkot",
                age = 20
            },
            new My()
            {
                id = 5,
                fname = "hingrajiya",
                lname = "jeet",
                city = "rajkot",
                age = 19
            },
            new My()
            {
                id = 6,
                fname = "sojitra",
                lname = "dhaval",
                city = "rajkot",
                age = 14
            }
            };
            return View(list);
        }
    }
}