namespace AspCat.Models
{
    public class Image
    {
        public int Id { get; set; }

        public Cat Cat { get; set; }

        public int CatId { get; set; }

        public byte[] Data { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public string ContentType { get; set; }
    }
}
