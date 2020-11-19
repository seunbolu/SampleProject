using SampleProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SampleProject.Controllers
{
    public class SessionController : Controller
    {
      
    
        private ApplicationDbContext _context;

        public SessionController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var _session = _context.Sessions.ToList();
            return View(_session);
        }
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Session session)
        {
            if (session.SessionId == 0)
            {
                _context.Sessions.Add(session);

            }
            else
            {
                var _session = _context.Sessions.Single(c => c.SessionId == session.SessionId);
                _session.SessionId = session.SessionId;
                _session.Name = session.Name;
                _session.StartDate = session.StartDate;
                _session.EndDate = session.EndDate;
                
           

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Session");

        }
        public ActionResult Edit(int Id)
        {
            var session = _context.Sessions.SingleOrDefault(c => c.SessionId == Id);
            //var student = _context.Students.SingleOrDefault(c => c.StudentId == Id);
            if (session == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            return View("New", session);
        }
        public ActionResult Delete(int Id)
        {
            var session = _context.Sessions.SingleOrDefault(c => c.SessionId == Id);
            //var _class = _context.tbl_Class.SingleOrDefault(c => c.Id == Id);
            _context.Sessions.Remove(session);
            _context.SaveChanges();

            return RedirectToAction("Index", "Session");
        }
    
    }
}