using AssignmentMvcEntity.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentMvcEntity.Controllers
{
    public class InventoryController : Controller
    {
        IInventoryInterface _repo;
        public InventoryController(IInventoryInterface repo)
        {
            _repo = repo;            
        }
        public IActionResult Index()
        {
            return View(_repo.GetInventory());
        }
        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Inventory inventory)
        {
            _repo.Create(inventory);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
           Inventory obj=  _repo.GetInventoryId(id);
            return View(obj);
        }
        [HttpPost]
        public IActionResult Deleted(int id)
        {
            Inventory obj = _repo.GetInventoryId(id);
            if (obj != null)
                _repo.Delete(obj.InventoryId);
           return RedirectToAction("Index");

        }
        public IActionResult Edit(int id)
        {
            Inventory obj=_repo.GetInventoryId(id);
            return View(obj);
        }
        [HttpPost]
        public IActionResult Edit(int id,Inventory inventory)
        {
            Inventory obj = _repo.GetInventoryId(id);
            if(obj != null)
                _repo.Edit(id,inventory);
            return RedirectToAction("Index");

        }

    }
}
