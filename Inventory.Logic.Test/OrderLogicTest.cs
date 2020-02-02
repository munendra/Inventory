using AutoMapper;
using Inventory.Domain;
using Inventory.Dto;
using Inventory.Logic.Implementations;
using Invetory.Repository.Contracts;
using Invetory.Repository.Implementations;
using Invetory.Repository.Test.Extension;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Inventory.Logic.Test
{
    public class OrderLogicTest
    {
        private OrderLogic orderLogic { get; set; }
        public InventoryContext InventoryContext { get; set; }
        public OrderLogicTest()
        {
            InventoryContext = InventoryContext.Create();
            orderLogic = new OrderLogic(new OrderRepository(InventoryContext));
        }

        [Fact]
        public void OrderLogic_Add_ShouldThrowExceptionIfOrderMasterIsNull()
        {
            OrderMaster orderMaster = null;
            Assert.Throws<Exception>(() => orderLogic.Add(orderMaster));
        }


        [Fact]
        public void OrderLogic_Add_ShouldThrowExceptionIfOrderDetailsIsNull()
        {
            var orderMasterId = Guid.NewGuid();
            var orderMaster = new OrderMaster
            {
                Id = orderMasterId,
                OrderAt = DateTime.UtcNow,
                OrderBy = "Person 1",
                OrderDetails = null

            };
            Assert.Throws<Exception>(() => orderLogic.Add(orderMaster));
        }

        [Fact]
        public void OrderLogic_Add_ShouldThrowExceptionIfItemIsNull()
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
                        ITems= null
                    }
                }
            };
            Assert.Throws<Exception>(() => orderLogic.Add(orderMaster));
        }

        [Fact]
        public void OrderLogic_Add_ShouldThrowExceptionIfOrderQuantityIsZero()
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
                        Quantity=0,
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

            Assert.Throws<Exception>(()=>orderLogic.Add(orderMaster));
        }

        [Fact]
        public void OrderLogic_Add_ShouldAddNewOrderInInventory()
        {
            var orderMaster = new OrderMaster
            {
                //Id = Guid.Empty,
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
                        Quantity=10,
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
            orderLogic.Add(orderMaster);
            var hasOrderPlaced = InventoryContext.OrderMaster.Any(o=>o.Id!=Guid.Empty);
            Assert.True(hasOrderPlaced);
        }

    }
}
