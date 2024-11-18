using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy_Management_System.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int MedicineId {  get; set; }
        public int Quantity {  get; set; }
        public decimal UnitPrice {  get; set; }
        public decimal Price {  get; set; }
        public virtual Order Order { get; set; } = default!;
        [ForeignKey("Order")]
        public int OrderId {  get; set; }

    }
}
