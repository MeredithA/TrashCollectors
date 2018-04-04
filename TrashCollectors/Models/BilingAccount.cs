using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollectors.Models
{
    public class BilingAccount
    {
        [Key]

        public int id { get; set; }

        public Customer Customer { get; set; }

        public int CustomerId { get; set; }

        public double Balance { get; set; }

        public string LastChargeDate { get; set; }
    }
}