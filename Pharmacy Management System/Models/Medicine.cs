using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy_Management_System.Models
{
    public class Medicine
    {
        [Display(Name ="Medicine Id ")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        [DataType(DataType.Date),Display(Name = "Expiry Date")]
        public DateTime ExpiryDate { get; set; }
        [DataType(DataType.Date),Display(Name = "Manufacturing Date")]
        public DateTime ManufacturingDate{get;set;}
        [Display(Name ="Price Per Unit")]
        public decimal PricePerUnit {  get; set; }
        public virtual ICollection<Order> orders { get; set; } = new HashSet<Order>();
        public virtual Stock? Stock { get; set; }
        [ForeignKey("Stock")]
        public int StockId {  get; set; }
    }
}
