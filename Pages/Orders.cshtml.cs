using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TransportCompany.Entities;

namespace TransportCompany.Pages
{
       
    [Authorize]
    public class OrdersModel : PageModel
    {
        public List<Employee> UsersData { get; set; }
        public void OnGet()
        {
            TransportdbContext db = new TransportdbContext();
            UsersData = db.Employees.ToList();
        }
    }
}
