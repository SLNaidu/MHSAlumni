using Microsoft.AspNetCore.Mvc;
using MHSAlumni.Models;
using MHSAlumni.DAL;

namespace MHSAlumni.Controllers
{
    public class HomeController : Controller
    {
        private MhsaluminiContext _context;
        public HomeController(MhsaluminiContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
