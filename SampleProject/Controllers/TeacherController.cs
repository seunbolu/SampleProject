using SampleProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SampleProject.Controllers
{
    public class TeacherController : Controller
    {

        private ApplicationDbContext _context;

        public TeacherController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Teacher
        public ActionResult Index()
        {
            var IsTeacher = _context.Teachers.ToList();
            return View(IsTeacher);
        }
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Teacher teacher)
        {
            if (teacher.TeacherId == 0)
            {
                _context.Teachers.Add(teacher);

            }  
            else
            {
               
                var teacherdb = _context.Teachers.Single(c => c.TeacherId == teacher.TeacherId);
                teacherdb.TeacherId = teacher.TeacherId;
                teacherdb.TeacherName = teacher.TeacherName;
                teacherdb.FatherName = teacher.FatherName;
                teacherdb.MobileNo = teacher.MobileNo;
                teacherdb.Address = teacher.Address;
                teacherdb.City = teacher.City;
                teacherdb.Gender = teacher.Gender;
                

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Teacher");

        }
        public ActionResult Edit(int Id)
        {
            var teacher = _context.Teachers.SingleOrDefault(c => c.TeacherId == Id);
            if (teacher == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            return View("New", teacher );
        }
        public ActionResult Delete(int Id)
        {
            var teacher = _context.Teachers.SingleOrDefault(c => c.TeacherId == Id);
            _context.Teachers.Remove(teacher);
            _context.SaveChanges();
            return RedirectToAction("Index", "Teacher");
        }
    }
}