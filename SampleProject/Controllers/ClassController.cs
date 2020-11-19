using SampleProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SampleProject.Controllers
{
    public class ClassController : Controller
    {
        private ApplicationDbContext _context;

        public ClassController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var _class = _context.tbl_Class.ToList();
            return View(_class);
        }
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Class _class)
        {
            if (_class.Id == 0)
            {
                _context.tbl_Class.Add(_class);

            }
            else
            {
                var cls = _context.tbl_Class.Single(c => c.Id == _class.Id);
                cls.Id = _class.Id;
                cls.ClassName = _class.ClassName;
                cls.Detail = _class.Detail;
                
           

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Class");

        }
        public ActionResult Edit(int Id)
        {
            var _class = _context.tbl_Class.SingleOrDefault(c => c.Id == Id);
            //var student = _context.Students.SingleOrDefault(c => c.StudentId == Id);
            if (_class == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            return View("New", _class);
        }
        public ActionResult Delete(int Id)
        {
            var _class = _context.tbl_Class.SingleOrDefault(c => c.Id == Id);
            _context.tbl_Class.Remove(_class);
            _context.SaveChanges();

            return RedirectToAction("Index", "Class");
        }
    }
}