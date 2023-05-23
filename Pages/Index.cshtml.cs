using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System.Linq;
using System.Security.Claims;
using TransportCompany.Entities;

namespace TransportCompany.Pages
{
    public class IndexModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;
        public string _login { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
            _login = Convert.ToString(HttpContext.User.FindFirst(ClaimTypes.Name));
        }


    }
}