using Inventory.Domain;
using Inventory.Domain.Entities;

namespace Invetory.Repository.Implementations
{
    public class OrderRepository
    {
        public InventoryContext InventoryContext { get; set; }
        public OrderRepository(InventoryContext inventoryContext)
        {
            InventoryContext = inventoryContext;
        }

        public void Add(OrderMaster orderMaster)
        {
            InventoryContext.OrderMaster.Add(orderMaster);
            InventoryContext.SaveChanges();
        }

    }
}
