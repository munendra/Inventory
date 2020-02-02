using Inventory.Logic.Contracts;
using Inventory.Logic.Validation;
using Invetory.Repository.Contracts;
using System.Collections.Generic;
using System.Linq;
namespace Inventory.Logic.Implementations
{
    public class OrderLogic : IOrderLogic
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IItemRepository _itemRepository;
        public OrderLogic(IOrderRepository orderRepository,IItemRepository itemRepository)
        {
            _orderRepository = orderRepository;
            _itemRepository = itemRepository;
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
                                    ItemId = order.ItemId
                                }).ToList()
            };
            _orderRepository.Add(_orderMaster);

        }

        public IList<Dto.OrderMaster> All()
        {
            var orders = _orderRepository.All();
            var itemIDs = orders.SelectMany(s => s.OrderDetails.Select(o => o.ItemId));
            var items = _itemRepository.All().Where(i => itemIDs.Contains(i.Id));

            var orderDto = from o in orders
                           select new Dto.OrderMaster()
                           {
                               Id = o.Id,
                               OrderAt = o.OrderAt,
                               OrderBy = o.OrderBy,
                               OrderDetails = (from od in o.OrderDetails
                                               select new Dto.OrderDetail
                                               {
                                                   Id = od.Id,
                                                   ItemId = od.ItemId,
                                                   OrderMasterId = od.OrderMasterId,
                                                   Quantity = od.Quantity,
                                                   Item =  (from i in items
                                                            where i.Id == od.ItemId
                                                            select new Dto.Item
                                                            {
                                                                Id = i.Id,
                                                                Name = i.Name,
                                                                Description = i.Description,
                                                                Price = i.Price,
                                                                Quantity = i.Quantity
                                                            }).FirstOrDefault()
                                               }).ToList()
                           };
            return orderDto.ToList();
        }
    }




}
