using SampleProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SampleProject.Controllers
{
    public class SubjectController : Controller
    {
        private ApplicationDbContext _context;

        public SubjectController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var _subject = _context.Subjects.ToList();
            return View(_subject);
        }
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Subject subject)
        {
            if (subject.SubjectId == 0)
            {
                _context.Subjects.Add(subject);

            }
            else
            {
                var _subject = _context.Subjects.Single(c => c.SubjectId == subject.SubjectId);
                _subject.SubjectId = subject.SubjectId;
                _subject.SubjectName = subject.SubjectName;

               

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Subject");

        }
        public ActionResult Edit(int Id)
        {
            var _subject = _context.Subjects.SingleOrDefault(c => c.SubjectId == Id);
            //var student = _context.Students.SingleOrDefault(c => c.StudentId == Id);
            if (_subject == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            return View("New", _subject);
        }
        public ActionResult Delete(int Id)
        {
            var _subject = _context.Subjects.SingleOrDefault(c => c.SubjectId == Id);
            _context.Subjects.Remove(_subject);
            _context.SaveChanges();
           
            return RedirectToAction("Index", "Subject");
        }
    }
}