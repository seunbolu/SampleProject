using SampleProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SampleProject.Controllers
{
    public class CityController : Controller
    {
        private ApplicationDbContext _context;

        public CityController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var _city = _context.Cities.ToList();
            return View(_city);
        }
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(City city)
        {
            if (city.CityId == 0)
            {
                _context.Cities.Add(city);

            }
            else
            {
                var _city = _context.Cities.SingleOrDefault(c => c.CityId == city.CityId);
                _city.CityId = city.CityId;
                _city.Name = city.Name;
                





            }
            _context.SaveChanges();

            return RedirectToAction("Index", "City");

        }
        public ActionResult Edit(int Id)
        {
            var city = _context.Cities.SingleOrDefault(c => c.CityId == Id);

            

            if (city == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            return View("New", city);
        }
        public ActionResult Delete(int Id)
        {
            var city = _context.Cities.SingleOrDefault(c => c.CityId == Id);


            _context.Cities.Remove(city);
            _context.SaveChanges();

            return RedirectToAction("Index", "City");
        }

    }

}