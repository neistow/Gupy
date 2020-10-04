﻿// <auto-generated />
using System;
using Gupy.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Gupy.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Gupy.Domain.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(55) CHARACTER SET utf8mb4")
                        .HasMaxLength(55);

                    b.Property<int?>("PhotoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PhotoId")
                        .IsUnique();

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Gupy.Domain.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("FileName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Photo");
                });

            modelBuilder.Entity("Gupy.Domain.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(55) CHARACTER SET utf8mb4")
                        .HasMaxLength(55);

                    b.Property<int?>("PhotoId")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("PhotoId")
                        .IsUnique();

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Gupy.Domain.Category", b =>
                {
                    b.HasOne("Gupy.Domain.Photo", "Photo")
                        .WithOne()
                        .HasForeignKey("Gupy.Domain.Category", "PhotoId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("Gupy.Domain.Product", b =>
                {
                    b.HasOne("Gupy.Domain.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gupy.Domain.Photo", "Photo")
                        .WithOne()
                        .HasForeignKey("Gupy.Domain.Product", "PhotoId")
                        .OnDelete(DeleteBehavior.SetNull);
                });
#pragma warning restore 612, 618
        }
    }
}
