using SampleProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SampleProject.ViewModel;
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
        public ActionResult New(Student student)
        {

            var viewModel = new CityViewModel
            {
                cities = _context.Cities.ToList(),
                Classes = _context.tbl_Class.ToList(),
                Sessions = _context.Sessions.ToList(),
                student=student

            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(CityViewModel cityViewModel)
        {
            if (cityViewModel.student.StudentId == 0)
            {
                _context.Students.Add(cityViewModel.student);

            }
            else
            {
                var studentdb = _context.Students.Single(c => c.StudentId == cityViewModel.student.StudentId);
                studentdb.RegId = cityViewModel.student.RegId;
                studentdb.StudentName = cityViewModel.student.StudentName;
                studentdb.FatherName = cityViewModel.student.FatherName;
                studentdb.MobileNo = cityViewModel.student.MobileNo;
                studentdb.Address = cityViewModel.student.Address;
                studentdb.City = cityViewModel.student.City;
                studentdb.Gender = cityViewModel.student.Gender;

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Student");

        }
        public ActionResult Edit(int Id)
        {
            var student = _context.Students.SingleOrDefault(c => c.StudentId == Id);
            if (student == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var viewModel = new CityViewModel
            {
                cities = _context.Cities.ToList(),
                student = student

            };

            return View("New", viewModel);
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