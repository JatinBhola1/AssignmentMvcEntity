using AssignmentMvcEntity.Context;
using AssignmentMvcEntity.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentMvcEntity.Controllers
{
    public class SupplierController : Controller
    {
        ISupplierInterface _repo;
        public SupplierController(ISupplierInterface repo)
        {

            _repo = repo;

        }
        public IActionResult Index()
        {
            return View(_repo.GetSupplier());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Supplier supplier)
        {
            _repo.Create(supplier);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Supplier obj = _repo.GetSupplierById(id);
            return View(obj);
        }
        [HttpPost]
        public IActionResult Deleted(int id)
        {
            Supplier obj = _repo.GetSupplierById(id);
            if (obj != null)
                _repo.Delete(obj.SupplierId);
            return RedirectToAction("Index");

        }
        public IActionResult Edit(int id)
        {
            Supplier obj = _repo.GetSupplierById(id);
            return View(obj);
        }
        [HttpPost]
        public IActionResult Edit(int id, Supplier supplier)
        {
            Supplier obj = _repo.GetSupplierById(id);
            if (obj != null)
                _repo.Edit(id,supplier);
            return RedirectToAction("Index");

        }
        public IActionResult Details(int id)
        {
            return View(_repo.GetSupplierById(id));
        }
    }
}
