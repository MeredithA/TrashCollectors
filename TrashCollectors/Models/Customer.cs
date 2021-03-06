﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollectors.Models
{
    public class Customer
    {

            [Key]
            public int ID { get; set; }
            [ForeignKey("UserId")]
            public ApplicationUser User { get; set; }
            public string UserId { get; set; }
            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }
            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
            [Display(Name = "Street Address")]
            public string StreetAddress { get; set; }
            [Required]
            [Display(Name = "City")]
            public string City { get; set; }
            [Required]
            [Display(Name = "State")]
            public string State { get; set; }
            [Required]
            [Display(Name = "Zip Code")]
            public int ZipCode { get; set; }
            [Required]
            [Display(Name = "Weekly Pick Up Day")]
            public string ScheduledPickUpDay { get; set; }
            [Display(Name = "Duration of Suspended Services")]
            public string SuspensionDuration { get; set; }
    }
}