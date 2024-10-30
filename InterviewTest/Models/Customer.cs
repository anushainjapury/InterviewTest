using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using InterviewTest.Orders;
using InterviewTest.Returns;

namespace InterviewTest.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; } //primary key


        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        public virtual ICollection<Return> Returns { get; set; } = new List<Return>();
    }
}
