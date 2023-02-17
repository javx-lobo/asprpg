using ASPRPG.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPRPG.Controllers
{
    public class HomeController : Controller
    {
        
       private readonly YourDbContext _context;

        public HomeController(YourDbContext context)
       {

            _context = context;
      }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Battle() 
        {
            return RedirectToAction("Index", "Battle");
        }

        public IActionResult Character() 
        {
            return RedirectToAction("Index", "Character");
        }

        public IActionResult Enemy() 
        {
            return RedirectToAction("Index", "Enemey");
        }

    }
}