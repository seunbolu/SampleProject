using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SampleProject.Models
{
    public class Section
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int SectionId { get; set; }
        public string Name { get; set; }
    }
}