using System;
using System.Linq;

namespace Inventory.Logic.Validation
{
    public static class OrderMaster
    {
        public static void Validate(this Dto.OrderMaster orderMaster)
        {
            ValidateOrderMaster(orderMaster);
            ValidateOrderDetails(orderMaster);
            ValidateOrderItems(orderMaster);
            ValidateOrderQuantity(orderMaster);
        }

        static void ValidateOrderMaster(Dto.OrderMaster orderMaster)
        {
            if (orderMaster == null)
            {
                throw new Exception("Invalid order request.");
            }
        }

        static void ValidateOrderDetails(Dto.OrderMaster orderMaster)
        {
            if (orderMaster.OrderDetails == null)
            {
                throw new Exception("Invalid order request.");
            }
        }

        static void ValidateOrderItems(Dto.OrderMaster orderMaster)
        {
            if (orderMaster.OrderDetails.Any(o=>o.ItemId==Guid.Empty))
            {
                throw new Exception("Invalid order request.");
            }
        }


        static void ValidateOrderQuantity(Dto.OrderMaster orderMaster)
        {
            if (orderMaster.OrderDetails.Any(o => o.Quantity == 0))
            {
                throw new Exception("Invalid order quantity.");
            }
        }

    }
}
