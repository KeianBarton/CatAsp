using System;

namespace AspCat.Models
{
    public class Cat
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public Breed Breed { get; set; }

        public int BreedId { get; set; }

        public Image Image { get; set; }

        public int? ImageId { get; set; }

        public double Weight { get; set; }

        public ApplicationUser Owner { get; set; }

        public string OwnerId { get; set; }

        public string GetAge()
        {
            var days = Math.Floor((DateTime.Now - BirthDate).TotalDays);
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