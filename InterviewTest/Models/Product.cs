using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace InterviewTest.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; } //primary key


        [Required]
        [MaxLength(20)]
        public string ProductNumber { get; set; } 

        // Selling Price
        [Column(TypeName = "decimal(18,2)")]
        public decimal SellingPrice { get; set; }
    }
}
