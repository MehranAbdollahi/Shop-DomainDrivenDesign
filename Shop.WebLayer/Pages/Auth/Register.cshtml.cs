using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.Users;
using Shop.Application.Users.DTOs;
using Shop.Application.Utilities;
using Shop.Contracts;

namespace Shop.WebLayer.Pages.Auth
{
    [BindProperties]
    [ValidateAntiForgeryToken]
    public class RegisterModel : PageModel
    {

        #region Properties

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = " {0} را وارد کنید")]
        public string UserName { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = " {0} را وارد کنید")]
        public string Email { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = " {0} را وارد کنید")]
        public string Password { get; set; }
        #endregion

        IUserService _userService;

        public RegisterModel(IUserService userService)
        {
            _userService = userService;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var res = _userService.RegisterUser(new UserRegisterDto()
            {
                UserName = UserName,
                Email = Email,
                PassWord = Password
            });

            if (res.Status == OperationResultStatus.Error)
            {
                ModelState.AddModelError("UserName", res.Message);
                return Page();
            }

            return RedirectToPage("login");
        }
    }
}
