using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace User_Authentication.Models
{
    public class ProductTypeSubCategory
    {
         
        [Key]
        public int ProductTypeSubCategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]

        public int ProductTypeId { get; set; }

        public ProductType ProductType { get; set; }

        [NotMappedAttribute]

        public int Quantity { get; set; }
    }
}

