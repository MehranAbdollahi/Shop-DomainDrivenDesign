using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Shop.Application.Users;
using Shop.Application.Users.DTOs;
using Shop.Application.Utilities;
using Shop.Contracts;

namespace Shop.WebLayer.Pages.Auth
{
    [BindProperties]
    [ValidateAntiForgeryToken]
    public class LoginModel : PageModel
    {
        private IUserService _userService;

        public LoginModel(IUserService userService)
        {
            _userService = userService;
        }

        #region Properties

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = " {0} را وارد کنید")]
        public string UserName { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = " {0} را وارد کنید")]
        public string PassWord { get; set; }
        #endregion

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = _userService.LoginUser(new UserLoginDto()
            {
                UserName = UserName,
                PassWord = PassWord
            });

            if (user == null)
            {
                ModelState.AddModelError("UserName", "کاربری با مشخصات وارد شده یافت نشد.");
                return Page();
            }

            #region Authentication
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties()
            {
                IsPersistent = true
            };
            HttpContext.SignInAsync(principal, properties);
            #endregion

            return RedirectToPage("../Index");
        }
    }
}
