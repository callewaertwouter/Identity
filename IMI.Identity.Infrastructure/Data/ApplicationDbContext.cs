using IMI.Identity.Core.Entities;
using IMI.Identity.Infrastructure.Data.Seeding;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IMI.Identity.Infrastructure.Data
{
	public class ApplicationDbContext : IdentityDbContext<User>
	{
        public DbSet<Recipe> Recipes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			UsersSeeder.Seed(builder);
			RecipeSeeder.Seed(builder);
		}
	}
}
