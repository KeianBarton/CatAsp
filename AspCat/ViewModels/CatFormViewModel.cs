using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AspCat.ViewModels
{
    public class CatFormViewModel
    {
        public string Name { get; set; }

        public string BirthDate { get; set; }

        public byte BreedId { get; set; }

        public IEnumerable<SelectListItem> Breeds { get; set; }

        public double Weight { get; set; }
    }
}
