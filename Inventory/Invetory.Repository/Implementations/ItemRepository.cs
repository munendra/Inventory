using Inventory.Domain;
using Inventory.Domain.Entities;
using Invetory.Repository.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Invetory.Repository.Implementations
{
    public class ItemRepository : IItemRepository
    {
        public InventoryContext InventoryContext { get; set; }

        public ItemRepository(InventoryContext inventoryContext)
        {
            InventoryContext = inventoryContext;
        }

        public void Add(Item item)
        {
            InventoryContext.Add(item);
            InventoryContext.SaveChanges();
        }

        public IEnumerable<Item> All()
        {
            return InventoryContext.Items.ToList();
        }
    }
}
