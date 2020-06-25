using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Models
{
    public class InvoiceProduct
    {
        public int ID { get; set; }
        public int ProductID { get; set; }

        [ForeignKey("ProductID")]
        public Product Product { get; set; }
        public int InvoiceID { get; set; }

        [ForeignKey("InvoiceID")]
        public Invoice Invoice { get; set; }
        public int Quantity { get; set; }
    }
}
