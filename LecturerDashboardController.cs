﻿using MyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject.Controllers
{

    [Authorize(Roles = "Lecturer")]  
    public class LecturerDashboardController : Controller
    {

        ApplicationDbContext db = new ApplicationDbContext();

        // GET: LecturerDashboard
        public ActionResult Dashboard()
        {
            ViewData["user"] = db.Users.ToList().Count();
            ViewData["course"] = db.Courses.ToList().Count();
            ViewData["Lecture"] = db.Lectures.ToList().Count();
            return View();
        }

        
    }
}