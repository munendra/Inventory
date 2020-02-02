using Inventory.Domain.Entities;

namespace Invetory.Repository.Contracts
{
    public interface IOrderRepository
    {
        void Add(OrderMaster orderMaster);
    }
}
