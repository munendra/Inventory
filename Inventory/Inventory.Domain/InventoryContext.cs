﻿using Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Inventory.Domain
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        {
        }

        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<OrderMaster> OrderMaster { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
    }
}
