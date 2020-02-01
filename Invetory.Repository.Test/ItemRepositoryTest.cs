using Inventory.Domain;
using Inventory.Domain.Entities;
using Invetory.Repository.Implementations;
using Invetory.Repository.Test.Extension;
using System;
using System.Linq;
using Xunit;

namespace Invetory.Repository.Test
{
    public class ItemRepositoryTest
    {
        public InventoryContext InventoryContext { get; set; }
        public ItemRepository ItemRepository { get; set; }
        public ItemRepositoryTest()
        {
            InventoryContext = InventoryContext.Create();
            ItemRepository = new ItemRepository(InventoryContext);
        }

        [Fact]
        public void ItemRepository_Add_ShouldAddRecordInInventoryItems()
        {
            var item = new Item
            {
                Id = Guid.NewGuid(),
                Price = 50.50 ,
                Quantity = 10
            };
            ItemRepository.Add(item);
            var hasItem = InventoryContext.Items.Any();
            Assert.True(hasItem);
        }


        [Fact]
        public void ItemRepository_All_ShouldReturnAllInventoryItems()
        {
            AddItems(2);
            var items = ItemRepository.All();
            Assert.Equal(3, items.Count());
        }


        void AddItems(int itemCount)
        {
            for (int i = 0; i <= itemCount; i++)
            {
                var item = new Item
                {
                    Id = Guid.NewGuid(),
                    Price = 50.50 + i,
                    Quantity = 10 + i
                };

                ItemRepository.Add(item);
            }

        }

        ~ItemRepositoryTest()
        {
            InventoryContext.Flush();
        }
    }
}
