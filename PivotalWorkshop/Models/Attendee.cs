using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PivotalWorkshop.Models
{
    public class Attendee
    {
        [Display(Name = "Attendee ID")]
        [Key]
        public int id { get; set; }

        [Display(Name = "First Name")]
        [StringLength(60)]
        public string firstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(60)]
        public string lastName { get; set;  }

        [Display(Name = "Name")]
        public string name { get { return firstName + " " + lastName; } }

        [Display(Name = "Email Address")]
        [StringLength(255)]
        public string email { get; set; }

        [Display(Name = "Phone Number")]
        [StringLength(20)]
        public string phoneNumber { get; set; }

        [Display(Name = "Address")]
        [StringLength(60)]
        public string address { get; set; }

        [Display(Name = "City")]
        [StringLength(60)]
        public string city { get; set; }

        [Display(Name = "State")]
        [StringLength(40)]
        public string state { get; set; }

        [Display(Name = "Postal Code")]
        [StringLength(10)]
        public string zipCode { get; set; }
    }
}