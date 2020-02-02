using System.Collections.Generic;

namespace Inventory.Logic.Contracts
{
    public interface IItemLogic
    {
        void Add(Dto.Item item);
        IEnumerable<Dto.Item> All();
    }
}
