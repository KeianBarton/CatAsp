using AspCat.Data;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;

namespace AspCat.Controllers
{
    public class ImagesController
    {
        private readonly ApplicationDbContext _context;

        public ImagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public FileStreamResult View(int id)
        {
            Models.Image image = _context.Images.FirstOrDefault(i => i.Id == id);
            if (image == null) return null;

            MemoryStream ms = new MemoryStream(image.Data);

            return new FileStreamResult(ms, image.ContentType);
        }
    }
}
