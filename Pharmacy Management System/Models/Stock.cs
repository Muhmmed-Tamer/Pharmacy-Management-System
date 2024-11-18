namespace Pharmacy_Management_System.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public int Quantity {  get; set; }
        public virtual ICollection<Medicine> Medicines { get; set; } = new HashSet<Medicine>();
    }
}
