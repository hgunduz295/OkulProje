using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Okul.BL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebUI.Models.Dto;

namespace WebUI.Controllers
{
    public class KullaniciController : Controller
    {
        private readonly IKullaniciManager manager;

        public KullaniciController(IKullaniciManager manager)
        {
            this.manager = manager;
        }

        public IActionResult Index()
        {
            var kullanicilar = manager.GetAll(null);
            return View(kullanicilar);
        }

        public IActionResult Giris()
        {
            LoginDto loginDto = new LoginDto();

            return View(loginDto);
        }

        [HttpPost]
        public async Task<IActionResult> Giris(LoginDto dto)
        {
            var user = manager.GetAll(x => x.UserName == dto.UserName && x.Password == dto.Password).FirstOrDefault();
            if (user != null)
            {

                //Cookie icerisinde saklanacak bilgileri tutan Claim tipinden Liste olusturyoruz.
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(ClaimTypes.Role,user.Role)
                };

                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                //var authenticationProperty = new AuthenticationProperties
                //{

                //    IsPersistent = model.RememberMe
                //};


                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme
                                        , new ClaimsPrincipal(claimIdentity));

                
                return RedirectToAction("Index", "Home", new { area = "Admin" });


            }
            else
            {
                return View();
            }
        }

        public IActionResult YetkiHatasi()
        {
            return View();

        }
    }
}
