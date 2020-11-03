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

                    b.Property<string>("Photo")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Gupy.Domain.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOrdered")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateShipped")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.Property<int>("ShippingDetailsId")
                        .HasColumnType("int");

                    b.Property<int?>("TelegramUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShippingDetailsId");

                    b.HasIndex("TelegramUserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Gupy.Domain.OrderItem", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<float>("PricePerUnit")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
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

                    b.Property<string>("Photo")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<float>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime?>("PromotionEndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<float?>("PromotionPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Gupy.Domain.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateReported")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Message")
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasMaxLength(4096);

                    b.Property<int>("ReportType")
                        .HasColumnType("int");

                    b.Property<int>("TelegramUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TelegramUserId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("Gupy.Domain.ShippingDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(64) CHARACTER SET utf8mb4")
                        .HasMaxLength(64);

                    b.Property<string>("ReceiverName")
                        .IsRequired()
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.Property<int>("TelegramUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TelegramUserId");

                    b.ToTable("ShippingDetails");
                });

            modelBuilder.Entity("Gupy.Domain.TelegramUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateJoined")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("varchar(64) CHARACTER SET utf8mb4")
                        .HasMaxLength(64);

                    b.Property<int>("TelegramId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("varchar(64) CHARACTER SET utf8mb4")
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.ToTable("TelegramUsers");
                });

            modelBuilder.Entity("Gupy.Domain.Order", b =>
                {
                    b.HasOne("Gupy.Domain.ShippingDetails", "ShippingDetails")
                        .WithMany("Orders")
                        .HasForeignKey("ShippingDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gupy.Domain.TelegramUser", null)
                        .WithMany("Orders")
                        .HasForeignKey("TelegramUserId");
                });

            modelBuilder.Entity("Gupy.Domain.OrderItem", b =>
                {
                    b.HasOne("Gupy.Domain.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gupy.Domain.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Gupy.Domain.Product", b =>
                {
                    b.HasOne("Gupy.Domain.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Gupy.Domain.Report", b =>
                {
                    b.HasOne("Gupy.Domain.TelegramUser", "TelegramUser")
                        .WithMany("Reports")
                        .HasForeignKey("TelegramUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Gupy.Domain.ShippingDetails", b =>
                {
                    b.HasOne("Gupy.Domain.TelegramUser", "TelegramUser")
                        .WithMany("ShippingDetails")
                        .HasForeignKey("TelegramUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
