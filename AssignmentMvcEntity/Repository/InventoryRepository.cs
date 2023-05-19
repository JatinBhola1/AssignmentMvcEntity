using AssignmentMvcEntity.Context;
using AssignmentMvcEntity.Models;

namespace AssignmentMvcEntity.Repository
{ 
    
    public class InventoryRepository : IInventoryInterface
    {
        InventoryDbContext _db;
        public InventoryRepository(InventoryDbContext db)
        {
            _db = db;
        }
        public Inventory Create(Inventory inventory)
        {
            _db.Inventories.Add(inventory);
            _db.SaveChanges();
            return inventory;
        }

        public int Delete(int id)
        {
            Inventory obj=GetInventoryId(id);
            if(obj != null)
            {
                _db.Inventories.Remove(obj);
                _db.SaveChanges();
                return 0;
            }else
                return 1;
        }

        public int Edit(int id, Inventory inventory)
        {
            Inventory obj=GetInventoryId(id);
            if(obj != null)
            {
                foreach(Inventory temp in _db.Inventories)
                {
                    if(temp.InventoryId == id)
                    {
                        temp.Name = inventory.Name;
                        temp.Details= inventory.Details;
                        temp.QtyInStock = inventory.QtyInStock;
                        temp.LastUpdated = DateTime.Now;
                    }
                }
                _db.SaveChanges();
                return 0;
            }else 
                return 1;
        }

        public List<Inventory> GetInventory()
        {
            return _db.Inventories.ToList();
        }

        public Inventory GetInventoryId(int id)
        {
            return _db.Inventories.FirstOrDefault(x => x.InventoryId == id);
        }
    }
}
