using AspCat.Data;
using AspCat.ViewModels;
using AspCat.ViewModels.CatViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;

namespace AspCat.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cats = _context.Cats
                .Include(c => c.Owner)
                .Include(c => c.Breed)
                .ToList();

            var viewModel = new CatsViewModel
            {
                Cats = cats,
                Heading = "Cats"
            };

            return View("Cats", viewModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
