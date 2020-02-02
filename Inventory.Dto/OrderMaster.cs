using System;
using System.Collections.Generic;

namespace Inventory.Dto
{
    public class OrderMaster
    {
        public OrderMaster()
        {
            OrderDetails = new List<OrderDetail>();
        }
        public Guid Id { get; set; }

        public DateTime OrderAt { get; set; }

        public string OrderBy { get; set; }

        public IList<OrderDetail> OrderDetails { get; set; }
    }
}
