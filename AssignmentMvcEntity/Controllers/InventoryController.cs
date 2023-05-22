using AssignmentMvcEntity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AssignmentMvcEntity.Controllers
{
    public class InventoryController : Controller
    {
        IInventoryInterface _repo;
        ISupplierInterface _repo1;
        public InventoryController(IInventoryInterface repo, ISupplierInterface repo1)
        {
            _repo = repo;
            _repo1 = repo1;

        }
        public IActionResult Index()
        {
            return View(_repo.GetInventory());
        }
        public IActionResult Create() {
            ViewData["SupplierId"] =
                    new SelectList(_repo1.GetSupplier(),
                    "SupplierId", "SupplierName"
                    );
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
        public IActionResult Deleted(int InventoryId)
        {
            _repo.Delete(InventoryId);
            return RedirectToAction("Index");

        }
        public IActionResult Edit(int id)
        {
            ViewData["SupplierId"] =
                    new SelectList(_repo1.GetSupplier(),
                    "SupplierId", "SupplierName"
                    );
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
        public IActionResult Details(int id)
        {
            return View(_repo.GetInventoryId(id));
        }

    }
}
