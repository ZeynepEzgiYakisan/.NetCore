using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Onion.JwtApp.Domain.Entities;
using Onion.JwtApp.Persistence.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Persistence.Context
{
    public class JwtContext : DbContext
    {
        
        public JwtContext(DbContextOptions<JwtContext> options) : base(options)
        {
        }

        public DbSet<Product>? Products { get; set; }

        public DbSet<Category>? Categories { get; set; }

        public DbSet<AppUser>? AppUsers { get; set; }

        public DbSet<AppRole>? AppRoles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
   
}
