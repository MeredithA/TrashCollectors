using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollectors.Models
{
    public class SuspendService
    {
        [Key]

        public int id { get; set; }

        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }

    }
}