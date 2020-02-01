﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Inventory.Domain.Migrations
{
    [DbContext(typeof(InventoryContext))]
    [Migration("20200201163520_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Inventory.Domain.Entities.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("OrderDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderDetailId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Inventory.Domain.Entities.OrderDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderMasterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderMasterId");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("Inventory.Domain.Entities.OrderMaster", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("OrderAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OrderMaster");
                });

            modelBuilder.Entity("Inventory.Domain.Entities.Item", b =>
                {
                    b.HasOne("Inventory.Domain.Entities.OrderDetail", null)
                        .WithMany("ITems")
                        .HasForeignKey("OrderDetailId");
                });

            modelBuilder.Entity("Inventory.Domain.Entities.OrderDetail", b =>
                {
                    b.HasOne("Inventory.Domain.Entities.OrderMaster", "OrderMaster")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderMasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
