using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TransportCompany.Entities;

namespace TransportCompany.Pages
{
    public class IndexModel : PageModel
    {
        public List<Employee> UsersData { get; set; }
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
            TransportdbContext db = new TransportdbContext();
            UsersData = db.Employees.ToList();
        }
    }
}