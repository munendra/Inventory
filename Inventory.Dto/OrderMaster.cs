using System;
using System.Collections.Generic;

namespace Inventory.Dto
{
    public class OrderMaster
    {
        public Guid Id { get; set; }

        public DateTime OrderAt { get; set; }

        public string OrderBy { get; set; }

        public IList<OrderDetail> OrderDetails { get; set; }
    }
}
