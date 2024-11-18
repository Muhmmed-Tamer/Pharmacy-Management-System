using Pharmacy_Management_System.Models;
using Pharmacy_Management_System.Reposatory;
using System.ComponentModel.DataAnnotations;

namespace Pharmacy_Management_System.ViewModel
{
    public class MedicineViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        [DataType(DataType.Date), Display(Name = "Expiry Date")]
        public DateTime ExpiryDate { get; set; }
        [DataType(DataType.Date), Display(Name = "Manufacturing Date")]
        public DateTime ManufacturingDate { get; set; }
        [Display(Name = "Price Per Unit")]
        public decimal PricePerUnit { get; set; }
        [Display(Name ="Stock")]
        public int StockId { get; set; }
        public List<Stock>? Stocks { get; set; } 
    }
}
