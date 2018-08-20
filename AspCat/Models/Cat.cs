using System;
using System.Collections.Generic;

namespace AspCat.Models
{
    public class Cat
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime? DeathDate { get; set; }

        public Breed Breed { get; set; }

        public int BreedId { get; set; }

        public bool IsDeceased { get; set; }

        public Image Image { get; set; }

        public double Weight { get; set; }

        public ApplicationUser Owner { get; set; }

        public string OwnerId { get; set; }

        public IList<Like> Likes { get; private set; }

        public bool IsDeleted { get; set; }

        public Cat()
        {
            Likes = new List<Like>();
        }

        public string GetAge()
        {
            double days;
            if (DeathDate != null)
            {
                days = Math.Floor((((DateTime) DeathDate) - BirthDate).TotalDays);
            }
            else
            {
                days = Math.Floor((DateTime.Now - BirthDate).TotalDays);
            }
            var years = days / 365.2425;
            if (years < 1) {
                var months = Math.Floor(years * 12);
                if (months < 1)
                {
                    return $"{(int) days} day{(((int) days == 1) ? "" : "s")}";
                }
                return $"{(int)months} month{(((int) months == 1) ? "" : "s")}";
            }
            return $"{(int)years} year{(((int) years == 1) ? "" : "s")}";
        }
    }
}