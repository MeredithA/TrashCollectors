using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollectors.Models
{
    public class WorkViewModel
    {
        public Employee Employee { get; set; }

        public List<Customer> Customers { get; set; }
    }
}