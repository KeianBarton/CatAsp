namespace AspCat.Models
{
    public class Like
    {
        public Cat Cat { get; set; }

        public ApplicationUser Liker { get; set; }

        public int CatId { get; set; }

        public string LikerId { get; set; }
    }
}
