using Inventory.Logic.Contracts;
using Inventory.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;

namespace Inventory.UI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderLogic _oderLogic;
        private readonly IItemLogic _itemLogic;
        public OrderController(IOrderLogic orderLogic, IItemLogic itemLogic)
        {
            _oderLogic = orderLogic;
            _itemLogic = itemLogic;
        }
        public IActionResult Add()
        {
            var orderModel = new OrderModel();
            orderModel.Items = _itemLogic.All().ToList();
            return View(orderModel);
        }

        [HttpPost]
        public IActionResult Add(OrderModel orderModel)
        {
            orderModel.Items = _itemLogic.All().ToList();
            var order = new Dto.OrderMaster()
            {
                OrderAt= DateTime.UtcNow,
                OrderBy= orderModel.OrderMaster.OrderBy,
                OrderDetails= orderModel.OrderDetail
            };
            _oderLogic.Add(order);
            return Redirect("/order/index");
        }


        public IActionResult Index()
        {
            
            return View();
        }
    }
}