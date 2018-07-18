using AspCat.Data;
using AspCat.Models;
using AspCat.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace AspCat.Controllers
{
    public class CatsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CatsController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var breeds = _context.Breeds.ToList().OrderBy(b => b.Name);
            var viewModel = new CatFormViewModel
            {
                Breeds = new SelectList(breeds, "Id", "Name")
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(CatFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var breeds = _context.Breeds.ToList().OrderBy(b => b.Name);
                viewModel.Breeds = new SelectList(breeds, "Id", "Name");
                return View("Create", viewModel);
            }

            var cat = new Cat
            {
                BirthDate = viewModel.GetBirthDate(),
                BreedId = (int) viewModel.BreedId,
                Name = viewModel.Name,
                OwnerId = _userManager.GetUserId(User),
                Weight = (double) viewModel.Weight
            };

            _context.Cats.Add(cat);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
