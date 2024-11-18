using Pharmacy_Management_System.Models;
using System.ComponentModel.DataAnnotations;

namespace Pharmacy_Management_System.ViewModel
{
    public class SellMedicineViewModel
    {
        [Display(Name ="Medicine Name")]
        public List<Medicine> Medicines { get; set; }
        [Display(Name = "Price Per Unit")]
        public decimal PricePerUnit {  get; set; }
        [Display(Name = "Number Of Units")]
        public int NumberOfUnits {  get; set; }
        [Display(Name = "Total Price")]
        public decimal TotalPrice {  get; set; }
        [Display(Name = "Expire Date")]
        public DateTime ExpireDate { get; set; }
        [Display(Name = "Medicines Want To Buy")]
        public int MedicineId {  get; set; }
    }
}
