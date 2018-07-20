using AspCat.Data;
using AspCat.Models;
using AspCat.Services;
using AspCat.ViewModels.CatViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AspCat.Controllers
{
    public class CatsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager _userManager;

        public CatsController(
            ApplicationDbContext context,
            UserManager userManager)
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
        [ValidateAntiForgeryToken]
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
                DeathDate = viewModel.GetDeathDate(),
                BreedId = (int) viewModel.BreedId,
                Name = char.ToUpper(viewModel.Name[0]) + viewModel.Name.Substring(1),
                OwnerId = _userManager.GetUserId(User),
                Weight = (double) viewModel.Weight,
                IsDeceased = viewModel.IsDeceased
            };

            _context.Cats.Add(cat);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
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

        [HttpGet]
        public IActionResult Mine()
        {
            var cats = _context.Cats
                .Include(c => c.Owner)
                .Include(c => c.Breed)
                .Where(c => c.OwnerId == _userManager.GetUserId(User))
                .ToList();

            var viewModel = new CatsViewModel
            {
                Cats = cats,
                Heading = "My Cats"
            };

            return View(viewModel);
        }
    }
}
