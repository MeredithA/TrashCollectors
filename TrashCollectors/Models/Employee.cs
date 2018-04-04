using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollectors.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("UserId")]

        public ApplicationUser User { get; set; }
        public string UserId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }
    }
}