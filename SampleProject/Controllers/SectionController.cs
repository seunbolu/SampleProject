using SampleProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SampleProject.Controllers
{
    public class SectionController : Controller
    {

        private ApplicationDbContext _context;

        public SectionController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var _section = _context.Sections.ToList();
            return View(_section);
        }
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Section section)
        {
            if (section.SectionId == 0)
            {
                _context.Sections.Add(section);

            }
            else
            {
                var _section = _context.Sections.Single(c => c.SectionId == section.SectionId);
                _section.SectionId = section.SectionId;
                _section.Name = section.Name;

                



            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Section");

        }
        public ActionResult Edit(int Id)
        {
            var section = _context.Sections.SingleOrDefault(c => c.SectionId == Id);

            //var session = _context.Sessions.SingleOrDefault(c => c.SessionId == Id);
            
            if (section == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            return View("New", section);
        }
        public ActionResult Delete(int Id)
        {
            var section = _context.Sections.SingleOrDefault(c => c.SectionId == Id);
            
           
            _context.Sections.Remove(section);
            _context.SaveChanges();

            return RedirectToAction("Index", "Section");
        }

    }

}