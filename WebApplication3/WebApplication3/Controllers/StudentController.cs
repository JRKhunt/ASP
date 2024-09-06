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
        public ActionResult Index(string nameFilter, string cityFilter)
        {
            var students = from s in db.Students
                           select s;

            if (!String.IsNullOrEmpty(nameFilter))
            {
                students = students.Where(s => s.fname.Contains(nameFilter) || s.lname.Contains(nameFilter));
            }

            if (!String.IsNullOrEmpty(cityFilter))
            {
                students = students.Where(s => s.city.Contains(cityFilter));
            }

            return View(students.ToList());
        }


        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(Student s)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(s);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(s);
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
