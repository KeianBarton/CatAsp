using AspCat.Data;
using AspCat.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AspCat.Controllers.Api
{
    [Route("api/cats")]
    public class CatsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager _userManager;

        public CatsController(UserManager userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpDelete("{catId}")]
        public IActionResult Delete(int catId)
        {
            // Logical delete
            var userId = _userManager.GetUserId(User);

            var cat = _context.Cats
                .SingleOrDefault(c => c.Id == catId && c.OwnerId == userId);
            if (cat.IsDeleted)
                return NotFound();

            cat.IsDeleted = true;
            _context.SaveChanges();

            return Ok();
        }
    }
}
