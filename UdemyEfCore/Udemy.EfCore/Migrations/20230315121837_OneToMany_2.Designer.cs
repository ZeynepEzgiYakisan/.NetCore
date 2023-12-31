﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UdemyEfCore.Data.Contexts;

namespace Udemy.EfCore.Migrations
{
    [DbContext(typeof(UdemyContext))]
    [Migration("20230315121837_OneToMany_2")]
    partial class OneToMany_2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("UdemyEfCore.Data.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("category_id")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("category_name");

                    b.HasKey("Id");

                    b.ToTable("Categories", "dbo");
                });

            modelBuilder.Entity("UdemyEfCore.Data.Entities.Customer", b =>
                {
                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Surnmae")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Number", "Name");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("UdemyEfCore.Data.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("product_id")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("product_name");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 3)
                        .HasColumnType("decimal(18,3)")
                        .HasColumnName("product_price");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Products");
                });

            modelBuilder.Entity("UdemyEfCore.Data.Entities.SaleHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("SaleHistories");
                });

            modelBuilder.Entity("UdemyEfCore.Data.Entities.SaleHistory", b =>
                {
                    b.HasOne("UdemyEfCore.Data.Entities.Product", "Product")
                        .WithMany("SaleHistories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("UdemyEfCore.Data.Entities.Product", b =>
                {
                    b.Navigation("SaleHistories");
                });
#pragma warning restore 612, 618
        }
    }
}
