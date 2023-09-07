using IMI.Identity.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IMI.Identity.Infrastructure.Data.Seeding;

public class RecipeSeeder
{
	public static void Seed(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Recipe>().HasData(
			new Recipe
			{
				Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
				Title = "Testrecept"
			}
			);
	}
}
