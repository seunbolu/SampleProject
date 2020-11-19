using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SampleProject.Models
{
    public class City
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int CityId { get; set; }
        public string Name { get; set; }
    }
}