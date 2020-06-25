using eShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.ViewModels
{
    public class InvoiceViewModel
    {
        public Invoice Invoice { get; set; }
        public List<InvoiceProduct> InvoiceProducts { get; set; }
    }
}
