using AspCat.Data;
using AspCat.Dtos;
using AspCat.Models;
using AspCat.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AspCat.Controllers.Api
{
    [Route("api/likes")]
    public class LikesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager _userManager;

        public LikesController (
            ApplicationDbContext context,
            UserManager userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        public IActionResult Like(LikeDto dto)
        {
            var userId = _userManager.GetUserId(User);
            var likeAlreadyExists = _context.Likes
                .Any(l => l.LikerId == userId && l.CatId == dto.CatId);

            if (likeAlreadyExists)
                return BadRequest("The like already exists.");

            var like = new Like
            {
                CatId = dto.CatId,
                LikerId = userId
            };

            _context.Likes.Add(like);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{catId}")]
        public IActionResult Delete(int catId)
        {
            var userId = _userManager.GetUserId(User);
            var like = _context.Likes.FirstOrDefault(l => l.LikerId == userId && l.CatId == catId);

            if (like == null)
                return NotFound();

            _context.Likes.Remove(like);
            _context.SaveChanges();

            return Ok(catId);
        }

    }
}