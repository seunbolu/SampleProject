using SampleProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SampleProject.Controllers
{
    public class StudentController : Controller
    {
        private ApplicationDbContext _context;

        public StudentController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //To display the list of Students
        public ActionResult Index()
        {
            var lststudent = _context.Students.ToList();
            return View(lststudent);
        }
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (student.StudentId == 0)
            {
                _context.Students.Add(student);

            }
            else
            {
                var studentdb = _context.Students.Single(c => c.StudentId == student.StudentId);
                studentdb.RegId = student.RegId;
                studentdb.StudentName = student.StudentName;
                studentdb.FatherName = student.FatherName;
                studentdb.MobileNo = student.MobileNo;
                studentdb.Address = student.Address;
                studentdb.City = student.City;
                studentdb.Gender = student.Gender;

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Student");

        }
        public ActionResult Edit(int Id)
        {
            var student = _context.Students.SingleOrDefault(c => c.StudentId == Id);
            if (student == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            return View("New", student);
        }
        public ActionResult Delete(int Id)
        {
            var student = _context.Students.SingleOrDefault(c => c.StudentId == Id);
            _context.Students.Remove(student);
            _context.SaveChanges();
            return RedirectToAction("Index", "Student");
        }
    }
}