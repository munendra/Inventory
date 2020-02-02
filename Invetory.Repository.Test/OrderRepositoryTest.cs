using Inventory.Domain;
using Inventory.Domain.Entities;
using Invetory.Repository.Implementations;
using Invetory.Repository.Test.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Invetory.Repository.Test
{
    public class OrderRepositoryTest
    {
        public InventoryContext InventoryContext { get; set; }
        public OrderRepository OrderRepository { get; }
        public OrderRepositoryTest()
        {
            InventoryContext = InventoryContext.Create();
            OrderRepository = new OrderRepository(InventoryContext);
        }

        [Fact]
        public void ItemRepository_Add_ShouldAddNewOrder()
        {
            var orderMasterId = Guid.NewGuid();
            var orderMaster = new OrderMaster
            {
                Id = orderMasterId,
                OrderAt = DateTime.UtcNow,
                OrderBy = "Person 1",
                OrderDetails = new List<OrderDetail>()
                {
                    new OrderDetail
                    {
                        Id= Guid.NewGuid(),
                        Quantity=2,
                         ItemId=Guid.NewGuid()
                        
                    },
                new OrderDetail
                {
                    Id = Guid.NewGuid(),
                    Quantity = 3,
                    ItemId= Guid.NewGuid()
                }
            }
            };
        OrderRepository.Add(orderMaster);
            var hasOrder = InventoryContext.OrderMaster.Any(o => o.Id == orderMasterId);
        Assert.True(hasOrder);
        }

    ~OrderRepositoryTest()
    {
        InventoryContext.Flush();
    }
}
}
