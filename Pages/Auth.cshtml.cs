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
            // ���� email �/��� ������ �� �����������, �������� ��������� ��� ������ 400
            if (!form.ContainsKey("Login") || !form.ContainsKey("Password"))
                return BadRequest("Email �/��� ������ �� �����������");

            string login = form["Login"];
            string password = form["Password"];

            // ������� ������������ 
            Employee? user = db.Employees.FirstOrDefault(p => p.Login == login && p.Pass == password);
            // ���� ������������ �� ������, ���������� ��������� ��� 401
            if (user is null) return Unauthorized();

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Login) };
            // ������� ������ ClaimsIdentity
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(claimsIdentity);
            // ��������� ������������������ ����
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            return Redirect(returnUrl ?? "/");
        }    
    }
}
