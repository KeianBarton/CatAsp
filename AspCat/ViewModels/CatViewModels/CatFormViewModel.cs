using AspCat.ViewModels.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspCat.ViewModels.CatViewModels
{
    public class CatFormViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [ValidDate(ErrorMessage = "Date of Birth is invalid; please use a past date in the format dd/mm/yyyy")]
        [Display(Name = "Date of Birth")]
        public string BirthDateText { get; set; }

        [Required(ErrorMessage = "Breed is required")]
        [Display(Name = "Breed")]
        public byte? BreedId { get; set; }

        public IEnumerable<SelectListItem> Breeds { get; set; }

        [Required(ErrorMessage = "Weight is required")]
        [Display(Name = "Weight (Kg)")]
        [Range(1, 50, ErrorMessage = "Weight must between 1kg and 50kg")]
        public double? Weight { get; set; }

        public DateTime GetBirthDate()
        {
            return DateTime.Parse(BirthDateText);
        }
    }
}
