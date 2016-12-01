using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace User_Authentication.Models
{
    public class ProductType
    {
        [Key]
        public int ProductTypeId { get; set; }

        [NotMappedAttribute]
        public int Quantity { get; set; }

        [Required]
        [StringLength(50)]
        public string Label { get; set; }
        public ICollection<Product> Products;
    }
}
