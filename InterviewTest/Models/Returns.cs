using InterviewTest.Orders;
using InterviewTest.Returns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace InterviewTest.Models
{
    public class Returns
    {
        [Key]
        public int ReturnId { get; set; } //Primary key

        
        public int OrderId { get; set; } //Foreign key
        public virtual Order OriginalOrder { get; set; }
        [Required]
        [MaxLength(20)]
        public string ReturnNumber { get; set; }

        
        public virtual ICollection<ReturnedProduct> ReturnedProducts { get; set; } = new List<ReturnedProduct>(); //returned products list





    }
}
