using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace User_Authentication.Models
{
        public class Product
        {
            [Key]
            public int ProductId { get; set; }

            [Required]
            [DataType(DataType.Date)]
            public DateTime DateCreated { get; set; }

            [Required]
            [StringLength(255)]
            public string Description { get; set; }

            [Required]
            [StringLength(55)]
            [DisplayAttribute(Name = "Name")]
            public string Title { get; set; }

            [Required]
            public decimal Price { get; set; }

            [Required]
            [DisplayAttribute(Name = "Category")]

            public int ProductTypeId { get; set; }
            public ProductType ProductType { get; set; }

            [Required]
            [DisplayAttribute(Name = "SubCategory")]
            public int ProductTypeSubCategoryId { get; set; }
            public ProductTypeSubCategory ProductTypeSubCategory { get; set; }

            [Required]
            public int CustomerId { get; set; }
            public Customer Customer { get; set; }
            public ICollection<LineItem> LineItem;

            [NotMappedAttribute]
            public int Quantity { get; set; }

            [NotMappedAttribute]

            public bool QuantityGreaterThanOne { get; set; }
        }
    }

