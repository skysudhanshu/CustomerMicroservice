﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace customer
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        [Required]
        public string FirstName{  get; set;}
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [DataType(DataType.DateTime)]
        public  DateTime DateOfBirth { get; set; }
        [Required]
        public string PanNumber { get; set; }
        
    }
}
