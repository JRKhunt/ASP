using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly RegistrationEntities _context;

        public RegistrationController()
        {
            _context = new RegistrationEntities();
        }

        // GET: Login

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Registration model)
        {
            if (ModelState.IsValid) // Validate the model
            {
                // Check if the email already exists in the database
                var existingUser = _context.Registrations
                    .FirstOrDefault(r => r.Email == model.Email);

                if (existingUser != null) // Email already exists
                {
                    // Show an alert or error message to the user
                    ModelState.AddModelError("Email", "This email is already registered.");

                    // Alternatively, if you want an alert box in JavaScript
                    TempData["EmailExists"] = "This email is already registered!";

                    // Return the same view with validation errors
                    return View(model);
                }

                // Add the new registration to the database
                _context.Registrations.Add(model);
                _context.SaveChanges();

                // Redirect to login page or show success message
                return RedirectToAction("Index", "Registration");
            }

            // If the model is not valid, return the same view with validation messages
            return View(model);
        }
    }
}

