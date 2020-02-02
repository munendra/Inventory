using Inventory.Logic.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.UI.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemLogic _itemLogic;
        public ItemController(IItemLogic itemLogic)
        {
            _itemLogic = itemLogic;
        }
        public IActionResult Index()
        {
           var items= _itemLogic.All();
            return View(items);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Dto.Item item)
        {
            _itemLogic.Add(item);
            return Redirect("/item");
        }
    }
}