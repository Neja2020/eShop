using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace eShop.EF
{
    public class MyContext:DbContext
    {
        public DbSet<City> City { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<InvoiceProduct> InvoiceProduct { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=Shop;Trusted_Connection=True; ");
        }
    }
}
