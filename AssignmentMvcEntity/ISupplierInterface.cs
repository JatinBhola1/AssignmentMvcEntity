using AssignmentMvcEntity.Models;

namespace AssignmentMvcEntity
{
    public interface ISupplierInterface
    {
        List<Supplier> GetSupplier();
        Supplier Create(Supplier supplier);
        Supplier GetSupplierById(int id);
        int Edit(int id, Supplier supplier);
        int Delete(int id);
    }
}
