using AspCat.ViewModels.Validation;
using Microsoft.AspNetCore.Http;
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

        [Required(ErrorMessage = "Date of birth is required")]
        [ValidBirthDate(ErrorMessage = "Date of birth is invalid; please use a past date in the format dd/mm/yyyy")]
        [Display(Name = "Date of birth")]
        public string BirthDateText { get; set; }

        [ValidDeathDate(ErrorMessage = "Date of death is invalid; please use a past date in the format dd/mm/yyyy")]
        [Display(Name = "Date of death")]
        public string DeathDateText { get; set; }

        [Required(ErrorMessage = "Breed is required")]
        [Display(Name = "Breed")]
        public byte? BreedId { get; set; }

        public IEnumerable<SelectListItem> Breeds { get; set; }

        [Required(ErrorMessage = "Weight is required")]
        [Display(Name = "Weight (Kg)")]
        [Range(1, 50, ErrorMessage = "Weight must between 1kg and 50kg")]
        public double? Weight { get; set; }

        [Required]
        [Display(Name = "Deceased?")]
        public bool IsDeceased { get; set; }

        [Display(Name = "Image")]
        public IFormFile Image { get; set; }

        public DateTime GetBirthDate()
        {
            return DateTime.Parse(BirthDateText);
        }

        public DateTime? GetDeathDate()
        {
            if (DeathDateText == null) return null;
            return DateTime.Parse(DeathDateText);
        }
    }
}
