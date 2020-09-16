using StudentRegistrationSystem.Models.Context;
using StudentRegistrationSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentRegistrationSystem.Controllers.Students
{
    public class SyllabusController : Controller
    {
        StudentRegistrationContext db = new StudentRegistrationContext();
        // GET: Syllabus
        public ActionResult Index()
        {
            ViewBag.Pazartesi = db.Sections.Where(d => d.Day == "Pazartesi" && d.Lecture.LectureID == d.LectureID).ToList();
            ViewBag.Salı = db.Sections.Where(d => d.Day == "Salı" && d.Lecture.LectureID == d.LectureID).ToList();
            ViewBag.Çarsamba = db.Sections.Where(d => d.Day == "Çarşamba" && d.Lecture.LectureID == d.LectureID).ToList();
            ViewBag.Persembe = db.Sections.Where(d => d.Day == "Perşembe" && d.Lecture.LectureID == d.LectureID).ToList();
            ViewBag.Cuma = db.Sections.Where(d => d.Day == "Cuma" && d.Lecture.LectureID == d.LectureID).ToList();
            return View(db.Lectures.ToList());
        }
    }
}