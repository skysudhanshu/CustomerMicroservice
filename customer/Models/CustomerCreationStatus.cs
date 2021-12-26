using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace customer.Models
{
    public class CustomerCreationStatus
    {
        [Key]
        public int CustomerId { get; set; }

        public string Status { get; set; }
    }
}
