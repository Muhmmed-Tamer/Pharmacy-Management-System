using Microsoft.AspNetCore.Identity;
using Pharmacy_Management_System.Models;
using Pharmacy_Management_System.Reposatory;
using System.ComponentModel.DataAnnotations;

namespace Pharmacy_Management_System.ViewModel
{
    public class AddUserViewModelWithAdminstroatorViewModel
    {
        [Display(Name ="User Name")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone,Display(Name ="Phone Number")]
        public string PhoneNumber {  get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthOfDate { get; set; }
        [Display(Name ="User Role")]
        public string  RoleId { get; set; }
        //List Roles
        public List<IdentityRole> ? Roles { get; set; }
        [Display(Name = "Choose Image ")]
        public IFormFile Image { get; set; }

    }
}
