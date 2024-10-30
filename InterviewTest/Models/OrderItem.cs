using InterviewTest.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using InterviewTest.Products;


namespace InterviewTest.Models
{
    public class OrderItem
    {
     
        public int OrderItemId { get; set; }  //primary key

        //foreign key
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }  

        
        public int ProductId { get; set; } //foreign key
        public virtual Product Product { get; set; }  

        
        public int Quantity { get; set; }

        
        [Column(TypeName = "decimal(18,2)")]
        public decimal ItemPrice { get; set; }
    }
}
