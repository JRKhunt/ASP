using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;


// install-package Entityframework


namespace WebApplication3.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            MyDBEntities db = new MyDBEntities();

            /* * Student std = new Student();
            std.fname = "ok";
            std.lname = "okkkkk";
            db.Students.Add(std);
            db.SaveChanges(); * */

            List<Student> stds = db.Students.ToList();
            return View(stds);
        }
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(Student s)
        {
            MyDBEntities db = new MyDBEntities();
            db.Students.Add(s);
            db.SaveChanges();
            return View();
        }
        public ActionResult Delete(int Id)
        {
            MyDBEntities db = new MyDBEntities();
            Student std = db.Students.Find(Id);
            db.Students.Remove(std);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}