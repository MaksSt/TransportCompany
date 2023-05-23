using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using TransportCompany.Entities;
using System;
using System.Security.Principal;

namespace TransportCompany.Pages
{
    public class AuthModel : PageModel
    {
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost(string? returnUrl)
        { 
            TransportdbContext db = new TransportdbContext();
            var form = HttpContext.Request.Form;
            // если email и/или пароль не установлены, посылаем статусный код ошибки 400
            if (!form.ContainsKey("Login") || !form.ContainsKey("Password"))
                return BadRequest("Email и/или пароль не установлены");

            string login = form["Login"];
            string password = form["Password"];

            // находим пользователя 
            Employee? user = db.Employees.FirstOrDefault(p => p.Login == login && p.Pass == password);
            // если пользователь не найден, отправляем статусный код 401
            if (user is null) return Unauthorized();

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Login) };
            // создаем объект ClaimsIdentity
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(claimsIdentity);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            return Redirect(returnUrl ?? "/");
        }    
    }
}
