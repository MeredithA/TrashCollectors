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
            //   [Required]
            public string FirstName { get; set; }
            //    [Required]
            public string LastName { get; set; }
            //  [Required]
            public string Address { get; set; }
            //    [Required]
            public string City { get; set; }
            //    [Required]
            public string State { get; set; }
            //   [Required]
            public int ZipCode { get; set; }
            //    [Required]
            public string ScheduledPickUpDay { get; set; }


            public double Balance { get; set; }
    }
}