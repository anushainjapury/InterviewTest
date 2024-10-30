using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InterviewTest.Customers;
using InterviewTest.Orders;

namespace InterviewTest.Models
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; } //primary key

 
        public int CustomerId { get; set; } //foreign key
        public virtual Customer Customer { get; set; }

        
        [Required]
        [MaxLength(20)]
        public string OrderNumber { get; set; }

        
        public virtual ICollection<OrderedProduct> Products { get; set; } = new List<OrderedProduct>(); //list of products


    }
}
