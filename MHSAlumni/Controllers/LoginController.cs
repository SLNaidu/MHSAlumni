using Microsoft.AspNetCore.Mvc;
using MHSAlumni.DAL;
using MHSAlumni.Models;

namespace MHSAlumni.Controllers
{
    public class LoginController : Controller
    {
        private MhsaluminiContext _context;
        public LoginController(MhsaluminiContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateAccount()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateAccount(Alumnus alumnus)
        {

            _context.Add(alumnus);
            _context.SaveChanges();
            return RedirectToAction("Index");



        }
        public IActionResult login(string Email, string password)
        {
            List<Alumnus> emailList = _context.Alumni.ToList();
            var alumnus = emailList.Where(v => v.Email == Email).FirstOrDefault();


            if (alumnus != null && alumnus.Password == password)
            {
                return RedirectToAction("Index", "Home");

            }
            else
            {
                if (alumnus == null)
                {
                    TempData["msg"] = "No Account found...!";
                }
                else
                {
                    TempData["msg"] = "Password is wrong...!";
                }

                return RedirectToAction("Index", "Login");

            }



        }
    }
}





