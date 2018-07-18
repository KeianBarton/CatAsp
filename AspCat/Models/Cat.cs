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

        public double Weight { get; set; }

        public ApplicationUser Owner { get; set; }

        public string OwnerId { get; set; }
    }
}