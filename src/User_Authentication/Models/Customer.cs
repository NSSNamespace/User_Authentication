using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace User_Authentication.Models
{
    //The customer class represents the customer table in the BangazonContext db
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }

        [Required]
        [DisplayAttribute(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayAttribute(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [DisplayAttribute(Name = "Street Address")]
        public string StreetAddress { get; set; }

        public ICollection<Product> Products;
    }
}
