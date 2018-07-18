using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspCat.ViewModels
{
    public class CatFormViewModel
    {
        public string Name { get; set; }

        public DateTime BirthDate {
            get
            {
                return DateTime.Parse(BirthDateText);
            }
        }

        [Display(Name = "Date of Birth")]
        public string BirthDateText { get; set; }

        [Display(Name = "Breed")]
        public byte BreedId { get; set; }

        public IEnumerable<SelectListItem> Breeds { get; set; }

        public double Weight { get; set; }
    }
}
