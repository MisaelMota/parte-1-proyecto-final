using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using parte_1_proyecto_final.Data;
using parte_1_proyecto_final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace parte_1_proyecto_final.Controllers
{
    public class AccessController1 : Controller
    {
        private readonly IConfiguration _configuration;

        public AccessController1(IConfiguration configuration )
        {
            this._configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> IndexAsync(UserModel _user)
        {
            DataLogic dataUser = new DataLogic(_configuration);
            var user = dataUser.Uservalidation(_user.Email, _user.Passw);
            if (user!=null)
            {
                var claims = new List<Claim> {

                    new Claim(ClaimTypes.Email,user.Email),
                    new Claim(ClaimTypes.Role,user.UserType)
                };


                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }

            
        }


        public async Task<IActionResult> logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "AccessController1");
        }




    }
}
