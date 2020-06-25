using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShop.Models;

namespace eShop.ViewModels
{
    public class CustomerViewModel
    {
        public Customer Customer { get; set; }
        public List<Invoice> Invoices { get; set; }
    }
}
