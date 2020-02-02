using Inventory.Domain;
using Inventory.Domain.Entities;
using Invetory.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Invetory.Repository.Implementations
{
    public class OrderRepository : IOrderRepository
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

        public IList<OrderMaster> All()
        {
            return InventoryContext.OrderMaster
                .Include(o => o.OrderDetails)
                .ToList();
        }

    }
}
