using Inventory.Domain.Entities;
using Inventory.Logic.Contracts;
using Inventory.Logic.Validation;
using Invetory.Repository.Contracts;
using System.Collections.Generic;
using System.Linq;
namespace Inventory.Logic.Implementations
{
    public class ItemLogic : IItemLogic
    {
        private readonly IItemRepository _itemRepository;
        public ItemLogic(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public void Add(Dto.Item item)
        {
            var itemEntity = new Item()
            {
                Name=item.Name,
                Description=item.Description,
                Price=item.Price,
                Quantity=item.Quantity
            };
            _itemRepository.Add(itemEntity);

        }

        public IEnumerable<Dto.Item> All()
        {
            var items = _itemRepository.All();
            var itemDto = from i in items
                          select new Dto.Item
                          {
                              Id = i.Id,
                              Name = i.Name,
                              Description = i.Description,
                              Price = i.Price,
                              Quantity = i.Quantity
                          };
            return itemDto;
        } 
    }




}
