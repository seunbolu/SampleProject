using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SampleProject.Models
{
    public class Teacher
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeacherId { get; set; }
         [Display (Name = "First Name")]
        public string TeacherName { get; set; }
        [Display(Name = "Last Name")]
        public string FatherName { get; set; }
        [Display(Name = "Mobile Number")]
        public int MobileNo { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "Gender")]
        public string Gender { get; set; }
    }
}