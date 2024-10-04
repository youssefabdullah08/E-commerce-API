using Microsoft.EntityFrameworkCore;
using Store.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Contexts
{
    public class StoreDBcontext : DbContext
    {
        public StoreDBcontext(DbContextOptions<StoreDBcontext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Entites.Type> Types { get; set; }
        public DbSet<DlivaryMethod> DlivaryMethods { get; set; }
    }
}
