using AspCat.ViewModels.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspCat.ViewModels
{
    public class CatFormViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [ValidDate]
        [Display(Name = "Date of Birth")]
        public string BirthDateText { get; set; }

        [Required]
        [Display(Name = "Breed")]
        public byte BreedId { get; set; }

        public IEnumerable<SelectListItem> Breeds { get; set; }

        [Required]
        [Display(Name = "Weight (Kg)")]
        public double Weight { get; set; }

        public DateTime GetBirthDate()
        {
            return DateTime.Parse(BirthDateText);
        }
    }
}
