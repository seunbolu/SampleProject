using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SampleProject.Models;
namespace SampleProject.ViewModel
{
    public class CityViewModel
    {
        public IEnumerable<City> cities { get; set; }
        public IEnumerable<Class> Classes { get; set; }
        public IEnumerable<Session> Sessions { get; set; }

        public Student student { get; set; }

    }
}