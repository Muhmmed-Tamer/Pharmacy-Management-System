using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pharmacy_Management_System.File_Settings;
using Pharmacy_Management_System.Models;
using Pharmacy_Management_System.Reposatory;
using Pharmacy_Management_System.ViewModel;
using System.Security.Claims;

namespace Pharmacy_Management_System.Controllers
{
    public class UserController : Controller
    {
        UserManager<User> UserManager;
        SignInManager<User> SignInManager;
        RoleManager<IdentityRole> RoleManager;
        
        IdentityRole Identity_Role;
        IReposatory<IdentityRole> _RolesReposatory;
        IWebHostEnvironment Server;
        User user; 
        public UserController(UserManager<User> _UserManager, SignInManager<User> _SignInManager,User _user, IWebHostEnvironment _Server, RoleManager<IdentityRole> _RoleManager, IdentityRole _IdentityRole, IReposatory<IdentityRole> RolesReposatory)
        {
            UserManager = _UserManager;
            SignInManager = _SignInManager;
            RoleManager = _RoleManager;
            Identity_Role = _IdentityRole;
            RolesReposatory = _RolesReposatory;
            Server = _Server;   
            user = _user;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }
       
        [ValidateAntiForgeryToken,HttpPost]
        public async Task<IActionResult> SaveLogin(UserLoginViewModel UserLogin)
        {
            if (ModelState.IsValid) {
                User user = await UserManager.FindByNameAsync(UserLogin.UserName);
                if (user is not null) { 
                    bool VaildPassword = await UserManager.CheckPasswordAsync(user, UserLogin.Password);
                    if (VaildPassword) {
                        //To Create Cookies For User 
                        await SignInManager.SignInAsync(user, UserLogin.RememberMe);
                        return View("MainPageOfPharmacy");
                    }
                    ModelState.AddModelError("", "User Name Or Password Is Not Vaild");
                }
            }
            return View("Login", User);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }
        [ValidateAntiForgeryToken, HttpPost]
        public async Task<IActionResult> SaveRegister(UserRegisterViewModel UserRegister) {
            if (ModelState.IsValid) {

                user.UserName = UserRegister.UserName;
                user.PasswordHash = UserRegister.Password;
                user.Email = UserRegister.Email;
                user.PhoneNumber = UserRegister.MobilePhone; 
                user.BirthOfDate = UserRegister.BirthOfDate;
                user.ImageURL = UserRegister.Image.FileName;
                //To Hashing The Password
                IdentityResult ValidUser = await UserManager.CreateAsync(user,UserRegister.Password);
                //Worning
                await UserManager.AddToRoleAsync(user, "Adminstrator");
                // Add Images In Server
                var FolderPath = $"{Server.WebRootPath}{Setting.FolderExtenstions}";
                var ImagePath = Path.Combine(FolderPath,UserRegister.Image.FileName);
                await  UserRegister.Image.CopyToAsync(new FileStream(ImagePath, FileMode.Create));

                if (ValidUser.Succeeded)
                {
                    //To Create Cookies Of User
                    await  SignInManager.SignInAsync(user,true);
                    RedirectToAction("MainPageOfPharmacy");
                }
                else {
                    ModelState.AddModelError("", "Please , Try In Later Some Thing Is Wrong");
                }
            }
            return View("Register",UserRegister);
        }
        [HttpGet]        
        public async Task<IActionResult> AddUser()
        {
            AddUserViewModelWithAdminstroatorViewModel AddUser = new AddUserViewModelWithAdminstroatorViewModel();
            AddUser.Roles = await RoleManager.Roles.ToListAsync(); 
            return View("AddUser" , AddUser);
        }
        [Authorize, HttpPost]
        public async Task<IActionResult> SaveAddUser(AddUserViewModelWithAdminstroatorViewModel AddUser)
        {
           AddUser.Roles = await RoleManager.Roles.ToListAsync();
            if (ModelState.IsValid) {
                if (AddUser.RoleId != null)
                {
                    user.UserName = AddUser.UserName;
                    user.PasswordHash = AddUser.Password;
                    user.Email = AddUser.Email;
                    user.PhoneNumber = AddUser.PhoneNumber;
                    user.BirthOfDate = AddUser.BirthOfDate;
                    user.ImageURL = AddUser.Image.FileName;
                    
                    //Add Image In Server
                    var FolderPath = $"{Server.WebRootPath}{Setting.FolderExtenstions}";
                    var ImagePath = Path.Combine(FolderPath, AddUser.Image.FileName);
                    await AddUser.Image.CopyToAsync(new FileStream(ImagePath, FileMode.Create));

                    IdentityResult VaildUser = await UserManager.CreateAsync(user, AddUser.Password);
                    Identity_Role.Id = AddUser.RoleId;
                    IdentityRole RoleUserChoosen = await RoleManager.FindByIdAsync(AddUser.RoleId);
                    await UserManager.AddToRoleAsync(user, RoleUserChoosen.Name);
                    return View("MainPageOfPharmacy");
                }
                ModelState.AddModelError("RoleId", "Use Must Choose Role ");
            }
            return View("AddUser", AddUser);
        }
        [HttpPost]
        public IActionResult MainPageOfPharmacy()
        {
            return View("MainPageOfPharmacy");
        }
        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return View("Login");
        }
        public IActionResult ViewUser()
        {
            List<User> user = UserManager.Users.ToList() ;
            return View("ViewUser" , user);
        }
        public async Task<IActionResult> Profile()
        {
            AddUserViewModelWithAdminstroatorViewModel UserToShareToView = new AddUserViewModelWithAdminstroatorViewModel();
            
            Claim ClaimId = User.Claims.FirstOrDefault(C=>C.Type==ClaimTypes.NameIdentifier);
            string Id = ClaimId.Value;
            User _User = await UserManager.FindByIdAsync(Id);
            UserToShareToView.UserName = _User.UserName;
            UserToShareToView.Email = _User.Email;
            UserToShareToView.BirthOfDate = _User.BirthOfDate;
            UserToShareToView.PhoneNumber = _User.PhoneNumber;            
            UserToShareToView.Roles = await RoleManager.Roles.ToListAsync();
            return View("Profile", UserToShareToView);
        }
        public async Task<IActionResult> SaveProfile(AddUserViewModelWithAdminstroatorViewModel UserToShareToView)
        {
            user.UserName = UserToShareToView.UserName;
            user.Email = UserToShareToView.Email;
            user.BirthOfDate = UserToShareToView.BirthOfDate;
            user.PhoneNumber = UserToShareToView.PhoneNumber;
            
            await UserManager.UpdateAsync(user);
            return View("MainPageOfPharmacy");
        }
    }
}
