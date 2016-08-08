using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyProject.Models;
using Microsoft.AspNet.Identity;
using System.IO;

namespace MyProject.Controllers
{
    public class LecturesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Lectures
        public ActionResult Index()
        {
            string getuser = User.Identity.GetUserId();
            var lectures = db.Lectures.Include(l => l.Course).Where(l => l.User.Id == getuser);
            return View(lectures.ToList());
        }

        // GET: Lectures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecture lecture = db.Lectures.Find(id);
            if (lecture == null)
            {
                return HttpNotFound();
            }
            string getuser = User.Identity.GetUserId();
            lecture.User = db.Users.Where(u => u.Id == getuser).Single();
            db.Lectures.Add(lecture);

            string coursename = db.Courses.Where(c => c.CourseId == lecture.CourseId).Single().CourseName;
            string uploadpath = Path.Combine(Server.MapPath("~/Content/Uploads/Lecturers/"), User.Identity.GetUserName(), coursename, lecture.LectureName + ".mp4");
            ViewData["lecture"] = uploadpath;
            return View(lecture);
        }

        // GET: Lectures/Create
        public ActionResult Create()
        {
            string getuser = User.Identity.GetUserId();
            
            ViewBag.CourseId = new SelectList(db.Courses.Where(c=>c.User.Id == getuser).ToList(), "CourseId", "CourseName");
            return View();
        }

        // POST: Lectures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LectureId,LectureName,CourseId,User")] Lecture lecture, HttpPostedFileBase upload)
        {

            if (ModelState.IsValid)
            {
                string getuser = User.Identity.GetUserId();
                lecture.User = db.Users.Where(u => u.Id == getuser).Single();
                db.Lectures.Add(lecture);
                if (upload.ContentLength > 0)
                {
                    string coursename = db.Courses.Where(c => c.CourseId == lecture.CourseId).Single().CourseName;
                    string uploadpath = Path.Combine(Server.MapPath("~/Content/Uploads/Lecturers/") ,  User.Identity.GetUserName() , coursename , lecture.LectureName + ".mp4");
                    upload.SaveAs(uploadpath);
                }
                db.SaveChanges();
                


                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", lecture.CourseId);
            return View(lecture);
        }

        // GET: Lectures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecture lecture = db.Lectures.Find(id);
            if (lecture == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", lecture.CourseId);
            return View(lecture);
        }

        // POST: Lectures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LectureId,LectureName,CourseId")] Lecture lecture, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lecture).State = EntityState.Modified;

                if (upload.ContentLength > 0)
                {
                    string coursename = db.Courses.Where(c => c.CourseId == lecture.CourseId).Single().CourseName;
                    string uploadpath = Path.Combine(Server.MapPath("~/Content/Uploads/Lecturers/"), User.Identity.GetUserName(), coursename, lecture.LectureName + ".mp4");
                    upload.SaveAs(uploadpath);
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", lecture.CourseId);
            return View(lecture);
        }

        // GET: Lectures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecture lecture = db.Lectures.Find(id);
            if (lecture == null)
            {
                return HttpNotFound();
            }
            return View(lecture);
        }

        // POST: Lectures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lecture lecture = db.Lectures.Find(id);
            db.Lectures.Remove(lecture);

            string coursename = db.Courses.Where(c => c.CourseId == lecture.CourseId).Single().CourseName;
            string uploadpath = Path.Combine(Server.MapPath("~/Content/Uploads/Lecturers/"), User.Identity.GetUserName(), coursename, lecture.LectureName + ".mp4");
            System.IO.File.Delete(uploadpath);

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
