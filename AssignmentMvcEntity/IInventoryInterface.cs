using AssignmentMvcEntity.Models;

namespace AssignmentMvcEntity
{
    public interface IInventoryInterface
    {

        List<Inventory> GetInventory();
        Inventory Create(Inventory inventory);
        Inventory GetInventoryId(int id);
        int Edit(int id, Inventory inventory);
        int Delete(int id);
    }
}
