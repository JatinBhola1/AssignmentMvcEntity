using System.ComponentModel.DataAnnotations;

namespace AssignmentMvcEntity.Models
{
    public class InventoryViewModel
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public int QtyInStock { get; set; }
        public DateTime LastUpdated { get; set; }
        
        public int SupplierId { get; set;}
        public string SupplierName { get; set; }
        public string ContactNo { get; set; }
    }
}
