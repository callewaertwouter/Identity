using IMI.Identity.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace IMI.Identity.Infrastructure.Data.Seeding
{
	public class UsersSeeder
	{
		public static void Seed(ModelBuilder modelBuilder)
		{
			IPasswordHasher<User> passwordHasher = new PasswordHasher<User>();

			// Generate a random GUID for the user's ID
			var userId = Guid.NewGuid().ToString();

			var imiUser = new User
			{
				Id = "00000000-0000-0000-0000-000000000001",
				UserName = "ImiUser",
				NormalizedUserName = "IMIUSER",
				Email = "user@imi.be",
				NormalizedEmail = "USER@IMI.BE",
				Birthday = new DateTime(1990, 1, 1),
				SecurityStamp = Guid.NewGuid().ToString(),
				ConcurrencyStamp = Guid.NewGuid().ToString(),
				EmailConfirmed = true,
				HasApprovedTermsAndConditions = true
			};

			imiUser.PasswordHash = passwordHasher.HashPassword(imiUser, "Test123?");
			modelBuilder.Entity<User>().HasData(imiUser);

			modelBuilder.Entity<IdentityRole>()
				.HasData(new IdentityRole
				{
					Id = "00000000-0000-0000-0000-000000000001",
					Name = "Admin",
					NormalizedName = "ADMIN"
				}
			);

			modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
			{
				RoleId = "00000000-0000-0000-0000-000000000001",
				UserId = "00000000-0000-0000-0000-000000000001"
			});
		}
	}
}
