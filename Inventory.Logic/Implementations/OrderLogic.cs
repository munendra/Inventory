using Inventory.Logic.Validation;
using Invetory.Repository.Contracts;
using System.Linq;
namespace Inventory.Logic.Implementations
{
    public class OrderLogic
    {
        private readonly IOrderRepository _orderRepository;
        public OrderLogic(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void Add(Dto.OrderMaster orderMaster)
        {
            orderMaster.Validate();
            var _orderMaster = new Domain.Entities.OrderMaster()
            {
                OrderBy = orderMaster.OrderBy,
                OrderAt = orderMaster.OrderAt,
                OrderDetails = (from order in orderMaster.OrderDetails
                                select new Domain.Entities.OrderDetail
                                {
                                    Quantity = order.Quantity,
                                    ITems = (from item in order.ITems
                                             select new Domain.Entities.Item
                                             {
                                                 Id = item.Id,
                                                 Description = item.Description,
                                                 Name = item.Name,
                                                 Price = item.Price,
                                                 Quantity = item.Quantity
                                             }).ToList()
                                }).ToList()
            };
            //_mapper.Map<Domain.Entities.OrderMaster>(orderMaster);
            _orderRepository.Add(_orderMaster);

        }
    }




}
