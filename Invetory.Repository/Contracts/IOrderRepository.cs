using Inventory.Domain.Entities;
using System.Collections.Generic;

namespace Invetory.Repository.Contracts
{
    public interface IOrderRepository
    {
        void Add(OrderMaster orderMaster);
        IList<OrderMaster> All();
    }
}
