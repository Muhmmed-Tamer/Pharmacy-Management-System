using Microsoft.AspNetCore.Identity;

namespace Pharmacy_Management_System.Models
{
    public class User:IdentityUser
    {
        public DateTime BirthOfDate {  get; set; }
        public string ImageURL { get; set; }    
        public virtual ICollection<Order> ?Orders { get; set; } = new HashSet<Order>();
    }
}
