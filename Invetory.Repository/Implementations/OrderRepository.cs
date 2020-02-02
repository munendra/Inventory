using Inventory.Domain;
using Inventory.Domain.Entities;
using Invetory.Repository.Contracts;

namespace Invetory.Repository.Implementations
{
    public class OrderRepository: IOrderRepository
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
