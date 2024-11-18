using System.ComponentModel.DataAnnotations;

namespace Pharmacy_Management_System.ViewModel
{
    public class UserRegisterViewModel
    {
        [Display(Name ="Name")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="Confirm Password"),Compare("Password"), DataType(DataType.Password)]
        public string ConfirmPassword {  get; set; }

        [EmailAddress]
        public string Email { get; set; }
        [Display(Name ="Birth Of Date") , DataType(DataType.Date)]
        public DateTime BirthOfDate { get; set; }
        [Phone,Display(Name ="Mobile Phone")]
        public string MobilePhone {  get; set; }
        [Display(Name = "Choose Image ")]
        public IFormFile Image { get; set; }    
    }
}
