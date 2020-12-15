using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoPartsCompany.Models;

namespace ProductsCompany.Models
{
    public class ProductsDBContext:DbContext
    {
        public ProductsDBContext(DbContextOptions<ProductsDBContext> options):base(options)
        {

        }

        public DbSet<ProductsModel> ProductsModel { get; set; }

        public DbSet<AutoPartsCompany.Models.OrderModel> OrderModel { get; set; }
    }
}
