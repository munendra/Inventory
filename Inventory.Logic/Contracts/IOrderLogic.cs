using System.Collections.Generic;

namespace Inventory.Logic.Contracts
{
    public interface IOrderLogic
    {
        void Add(Dto.OrderMaster orderMaster);
        IList<Dto.OrderMaster> All();
    }
}
