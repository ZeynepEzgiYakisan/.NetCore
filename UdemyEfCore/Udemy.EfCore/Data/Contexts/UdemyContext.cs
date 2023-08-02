using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyEfCore.Data.Entities;

namespace UdemyEfCore.Data.Contexts
{
    public class UdemyContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<SaleHistory> SaleHistories { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<ProductDetail> ProductDetails { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<PartTimeEmployee> PartTimeEmployees { get; set; }

        public DbSet<FullTimeEmployee> FullTimeEmployees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.\\SQLEXPRESS;database=UdemyEfCore;integrated security=true;");
            // optionsBuilder.UseSqlServer(" Server = LAPTOP - FSO383FF; Database = UdemyEfCoreWebApi; Trusted_Connection = True; Connect Timeout = 30; MultipleActiveResultSets = True);
            // optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB; Initial Catalog =[UdemyEfCore]; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
           // optionsBuilder.UseSqlServer("Server=(localdb);Database=[UdemyEfCoree]i;TrustServerCertificate=True;Integrated Security=true;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Customer>().HasNoKey();

            //modelBuilder.Entity<Product>().HasMany(x => x.SaleHistories).WithOne( x => x.Product).HasForeignKey( x => x.ProductId);

            modelBuilder.Entity<ProductCategory>().HasKey(x => new { x.CategoryId, x.ProductId }); //Bu iki konum primary key olarak tanýmladýk

            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<FullTimeEmployee>().ToTable("FullTimeEmployees");
            modelBuilder.Entity<PartTimeEmployee>().ToTable("PartTimeEmployees");


            modelBuilder.Entity<Product>().HasMany(x => x.ProductCategories).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);

            modelBuilder.Entity<Category>().HasMany(x => x.ProductCategories).WithOne(x => x.Category).HasForeignKey(x => x.ProductId);

            modelBuilder.Entity<Product>().HasOne(x => x.ProductDetail).WithOne(x =>
             x.Product).HasForeignKey<ProductDetail>(x => x.ProductId);

            modelBuilder.Entity<SaleHistory>().HasOne(x => x.Product).WithMany(x => x.SaleHistories).HasForeignKey(x => x.ProductId);

            modelBuilder.Entity<Category>().ToTable(name: "Categories", schema: "dbo");

            modelBuilder.Entity<Customer>().HasKey(x => new { x.Number, x.Name });

            modelBuilder.Entity<Product>().Property(x => x.Name).HasColumnName("product_name");
            modelBuilder.Entity<Product>().Property(x => x.Name).HasMaxLength(100);
            modelBuilder.Entity<Product>().HasIndex(x => x.Name).IsUnique(true);
            modelBuilder.Entity<Product>().Property(x => x.Name).IsRequired();
            //modelBuilder.Entity<Product>().Property(x => x.Name).HasDefaultValueSql("'Urun adi girilmedi'");

            modelBuilder.Entity<Product>().Property(x => x.CreatedTime).HasDefaultValueSql("getdate()");


            modelBuilder.Entity<Product>().Property(x => x.Id).HasColumnName("product_id");

            modelBuilder.Entity<Product>().Property(x => x.Price).HasColumnName("product_price");
            modelBuilder.Entity<Product>().Property(x => x.Price).HasPrecision(18, 3);


            base.OnModelCreating(modelBuilder);
        }
    }
}
