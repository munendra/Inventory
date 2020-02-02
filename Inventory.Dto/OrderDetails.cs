using System;
using System.Collections.Generic;

namespace Inventory.Dto
{
    public class OrderDetail
    {
        public Guid Id { get; set; }

        public IList<Item> ITems { get; set; }

        public int Quantity { get; set; }

        public Guid OrderMasterId { get; set; }

        public OrderMaster OrderMaster { get; set; }
    }
}
