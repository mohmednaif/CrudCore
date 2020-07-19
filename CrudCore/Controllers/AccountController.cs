using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CrudCore.Models;
using Infrastructure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace CrudCore.Controllers
{
    public class AccountController : Controller
    {
        private readonly ICommonService conmmonService;

        public AccountController(ICommonService conmmonService)
        {
            this.conmmonService = conmmonService;
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {

                var userRoles = ((ClaimsIdentity)User.Identity).Claims
                                                               .Where(c => c.Type == ClaimTypes.Role)
                                                               .Select(c => c.Value).ToList();

                if (userRoles.Contains(Utility.Role.Admin.ToString()))
                    return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                if (userRoles.Contains(Utility.Role.FinanceManager.ToString()))
                    return RedirectToAction("Index", "Dashboard", new { area = "Finance" });
                if (userRoles.Contains(Utility.Role.HRManager.ToString()))
                    return RedirectToAction("Index", "Dashboard", new { area = "HR" });

            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginViewModel loginViewModel, string returnUrl)
        {

            Domain.User user = conmmonService.GetUserByUserNamePassword(loginViewModel.User);
            if (user != null)
            {
                //---------------------------------------------------------------------------------------------------
                //Authorization Begin

                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

                identity.AddClaim(new Claim(ClaimTypes.Role, Enum.GetName(typeof(Utility.Role), user.RoleId)));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.Username));

                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    principal,
                    new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTime.UtcNow.AddDays(1),
                    });

                //Authorization End


                //Session Begin
                //HttpContext.Session.SetString("SessionName", "Session Value");
                HttpContext.Session.Set<Domain.User>("user", user);
                //Session End


                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    return Redirect(returnUrl);
                else
                {
                    if (user.RoleId == (int)Utility.Role.Admin)
                        return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                    if (user.RoleId == (int)Utility.Role.FinanceManager)
                        return RedirectToAction("Index", "Dashboard", new { area = "Finance" });
                    if (user.RoleId == (int)Utility.Role.HRManager)
                        return RedirectToAction("Index", "Dashboard", new { area = "HR" });
                }

            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            //return LocalRedirect("Account/Login");
            return RedirectToAction("Login", "Account");
        }





    }
}
