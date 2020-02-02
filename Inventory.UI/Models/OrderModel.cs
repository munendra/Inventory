using Inventory.Dto;
using System.Collections.Generic;

namespace Inventory.UI.Models
{
    public class OrderModel
    {

        public OrderMaster OrderMaster { get; set; }

        public List<OrderDetail> OrderDetail { get; set; }

        public List<Item> Items { get; set; }

    }
}
