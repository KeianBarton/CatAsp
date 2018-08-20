using AspCat.Data;
using AspCat.Models;
using AspCat.Services;
using AspCat.ViewModels.CatViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;

namespace AspCat.Controllers
{
    public class CatsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager _userManager;

        public CatsController (
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
                Breeds = new SelectList(breeds, "Id", "Name"),
                Heading = "Add a Cat"
            };
            return View("CatForm", viewModel);
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
                return View("CatForm", viewModel);
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

            IFormFile uploadedImage = viewModel.Image;
            if (uploadedImage != null && uploadedImage.ContentType.ToLower().StartsWith("image/"))
            {
                MemoryStream ms = new MemoryStream();
                uploadedImage.OpenReadStream().CopyTo(ms);

                System.Drawing.Image image = System.Drawing.Image.FromStream(ms);

                var imageEntity = new Image
                {
                    Cat = cat,
                    ContentType = uploadedImage.ContentType,
                    Data = ms.ToArray(),
                    Width = image.Width,
                    Height = image.Height
                };

                _context.Images.Add(imageEntity);
            }

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
                .Include(c => c.Likes)
                .Include(c => c.Image)
                .Where(c => c.IsDeleted == false)
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
                .Include(c => c.Likes)
                .Include(c => c.Image)
                .Where(c => c.OwnerId == _userManager.GetUserId(User) && c.IsDeleted == false)
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
