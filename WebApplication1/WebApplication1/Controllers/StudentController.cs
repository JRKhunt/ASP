using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            List<Student> list = new List<Student>()
            {
                new Student()
                {
                    ID = 1,
                    NAME = "Jay",
                    CITY = "Rajkot"
                },
                new Student()
                {
                    ID = 2,
                    NAME = "Darshil",
                    CITY = "Rajkot"
                },
            new Student()
            {
                ID = 3,
                NAME = "Amit",
                CITY = "Rajkot"
            }
            };
            return View(list);
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(string x, string y, string operation)
        {
            double num1, num2;
            if (!double.TryParse(x, out num1) || !double.TryParse(y, out num2))
            {
                ViewBag.Error = "Please enter valid numbers.";
                return View("Contact"); 
            }

            double result = 0;
            switch (operation)
            {
                case "add +":
                    result = num1 + num2;
                    break;
                case "sub -":
                    result = num1 - num2;
                    break;
                case "mul *":
                    result = num1 * num2;
                    break;
                case "div /":
                    if (num2 == 0)
                    {
                        ViewBag.Error = "Division by zero is not allowed.";
                        return View("Contact"); 
                    }
                    result = num1 / num2;
                    break;
                default:
                    ViewBag.Error = "Invalid operation selected.";
                    return View("Contact"); 
            }

            ViewBag.Result = result;
            return View("Contact"); 
        }
    }
}