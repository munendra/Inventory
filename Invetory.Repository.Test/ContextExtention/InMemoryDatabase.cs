using Inventory.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Invetory.Repository.Test.Extension
{
    public static class InMemoryDatabase
    {
        public static InventoryContext Create(this InventoryContext inventoryContext)
        {
            var options = new DbContextOptionsBuilder<InventoryContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new InventoryContext(options);
            context.Database.EnsureCreated();
            return context;
        }
        public static void Flush(this InventoryContext inventoryContext)
        {
            inventoryContext.Database.EnsureDeleted();
            inventoryContext.Dispose();
        }


    }
}
