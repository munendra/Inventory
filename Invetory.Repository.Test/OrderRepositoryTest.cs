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
                        ITems= new List<Item>()
                        {
                            new Item
                            {
                                Id= Guid.NewGuid(),
                                Name="Name 1",
                                Description="Desc 1",
                                Price=50,
                                Quantity=5
                            },
                            new Item
                            {
                                Id= Guid.NewGuid(),
                                Name="Name 2",
                                Description="Desc 2",
                                Price=50,
                                Quantity=5
                            },

                        }
                    },
                    new OrderDetail
                    {
                        Id= Guid.NewGuid(),
                        Quantity=3,
                        ITems= new List<Item>()
                        {
                            new Item
                            {
                                Id= Guid.NewGuid(),
                                Name="Name 1",
                                Description="Desc 1",
                                Price=50,
                                Quantity=5
                            },
                            new Item
                            {
                                Id= Guid.NewGuid(),
                                Name="Name 2",
                                Description="Desc 2",
                                Price=50,
                                Quantity=5
                            },
                            new Item
                            {
                                Id= Guid.NewGuid(),
                                Name="Name 3",
                                Description="Desc 3",
                                Price=500,
                                Quantity=20
                            },

                        }
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
