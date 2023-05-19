using AssignmentMvcEntity.Context;
using AssignmentMvcEntity.Models;

namespace AssignmentMvcEntity.Repository
{
    public class SupplierRepository : ISupplierInterface
    {
        InventoryDbContext _db;
        public SupplierRepository(InventoryDbContext db)
        {
            _db = db;
        }
        public Supplier Create(Supplier supplier)
        {
           _db.Suppliers.Add(supplier);
            _db.SaveChanges();
            return supplier;
        }

        public int Delete(int id)
        {
           Supplier obj=GetSupplierById(id);
            if(obj!=null)
            {
                _db.Suppliers.Remove(obj); 
                _db.SaveChanges();
                return 0;
            }
            else
                return 1;
        }

        public int Edit(int id, Supplier supplier)
        {
            Supplier obj=GetSupplierById(id);
            if (obj != null)
            {
                foreach (Supplier temp in _db.Suppliers)
                {
                    if (temp.SupplierId == id)
                    {
                        temp.SupplierName = supplier.SupplierName;
                        temp.Address = supplier.Address;
                        temp.Email = supplier.Email;
                        temp.ContactNo = supplier.ContactNo;
                        temp.CityOperatesIn = supplier.CityOperatesIn;
                    }
                }
                _db.SaveChanges();
                return 0;

            }
            else return 1;
        }

        public List<Supplier> GetSupplier()
        {
            return _db.Suppliers.ToList();
        }

        public Supplier GetSupplierById(int id)
        {
           return _db.Suppliers.FirstOrDefault(x=>x.SupplierId==id);
        }
    }
}
