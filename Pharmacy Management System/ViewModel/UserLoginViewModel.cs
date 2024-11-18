using System.ComponentModel.DataAnnotations;

namespace Pharmacy_Management_System.ViewModel
{
    public class UserLoginViewModel
    {
        [Display(Name ="User Name")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="Remember Me")]
        public bool RememberMe {  get; set; }
    }
}
