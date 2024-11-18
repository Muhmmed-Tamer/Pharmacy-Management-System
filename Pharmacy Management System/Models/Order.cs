using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy_Management_System.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice {  get; set; }
        public virtual User User { get; set; } = default!;//Customer
        [ForeignKey("User")]
        public string UserId {  get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
        public virtual ICollection<Medicine> Medicines { get; set; } = new HashSet<Medicine>();
        
    }
}
