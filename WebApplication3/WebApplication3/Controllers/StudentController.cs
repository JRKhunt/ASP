using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class StudentController : Controller
    {
        private MyDBEntities db = new MyDBEntities();

        // GET: Student
        public ActionResult Index(string fnameFilter)
        {
            var students = string.IsNullOrEmpty(fnameFilter)
                ? db.Students.ToList()
                : db.Students.Where(s => s.fname.Contains(fnameFilter)).ToList();

            ViewBag.FnameFilter = fnameFilter;
            return View(students);
        }

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(Student s)
        {
            db.Students.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            Student std = db.Students.Find(Id);
            if (std != null)
            {
                db.Students.Remove(std);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteSelected(int[] selectedIds)
        {
            if (selectedIds != null && selectedIds.Length > 0)
            {
                foreach (var id in selectedIds)
                {
                    Student student = db.Students.Find(id);
                    if (student != null)
                    {
                        db.Students.Remove(student);
                    }
                }
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)
        {
            Student std = db.Students.Find(Id);
            if (std == null)
            {
                return HttpNotFound();
            }
            return View(std);
        }

        [HttpPost]
        public ActionResult Edit(Student s)
        {
            if (ModelState.IsValid)
            {
                db.Entry(s).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(s);
        }
    }
}
