using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_Authentication.Data;
using User_Authentication.Models;

namespace User_Authentication.Models.ViewModels
{
    public class PaymentTypeViewModel    
    {

        public PaymentType PaymentType { get; set; }
        public PaymentTypeViewModel(ApplicationDbContext ctx){ }
    }
}
