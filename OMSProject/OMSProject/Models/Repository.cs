using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMSProject.Models
{
    public class Repository:DbContext
    {
        public Repository(DbContextOptions<Repository> options) : base(options) { }

        public DbSet<Users> Users { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
    }
}
