using Microsoft.EntityFrameworkCore.Migrations;

namespace AspCat.Data.Migrations
{
    public partial class InitialBreeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var breeds = new string[]
            {
                "Domestic Shorthair",
                "Domestic Longhair",
                "Maine Coon",
                "Siamese",
                "American Shorthair",
                "Abyssinian",
                "Exotic Shorthair",
                "Ragdoll",
                "Burmese",
                "Himalayan"
            };

            foreach (var breed in breeds)
            {
                migrationBuilder.Sql("INSERT INTO BREEDS (Name) VALUES ('" + breed + "');");
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM BREEDS");
        }
    }
}
