using Inventory.Domain.Entities;
using System.Collections.Generic;

namespace Invetory.Repository.Contracts
{
    public interface IItemRepository
    {
        void Add(Item item);

        IEnumerable<Item> All();
    }
}
