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
                Price = 50.50,
                Quantity = 10
            };

            ItemRepository.Add(item);
            var hasItem = InventoryContext.Items.Any();
            Assert.True(hasItem);
        }



        ~ItemRepositoryTest()
        {
            InventoryContext.Flush();
        }
    }
}
