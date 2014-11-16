namespace Streamus.Data.Migrations
{
	using Microsoft.AspNet.Identity;
	using Microsoft.AspNet.Identity.EntityFramework;
	using Streamus.Common;
	using Streamus.Data.Models;
	using System.Data.Entity.Migrations;
	using System.Linq;

	internal sealed class Configuration : DbMigrationsConfiguration<StreamusDbContext>
	{
		private UserManager<User> userManager;

		public Configuration()
		{
			this.AutomaticMigrationsEnabled = true;
			this.AutomaticMigrationDataLossAllowed = true;
		}

		protected override void Seed(StreamusDbContext context)
		{
			this.userManager = new UserManager<User>(new UserStore<User>(context));
			this.SeedRoles(context);
			this.SeedUsers(context);
		}

		private void SeedRoles(StreamusDbContext context)
		{
			if (context.Roles.Any())
			{
				return;
			}

			context.Roles.AddOrUpdate(x => x.Name, new IdentityRole(AppRoles.Admin));
			context.Roles.AddOrUpdate(x => x.Name, new IdentityRole(AppRoles.User));
			context.SaveChanges();
		}

		private void SeedUsers(StreamusDbContext context)
		{
			if (context.Users.Any())
			{
				return;
			}

			for (int userIndex = 1; userIndex <= 10; userIndex++)
			{
				var email = string.Format("{0}{1}@{0}.com", "test", userIndex);

				var user = new User
				{
					Email = email,
					UserName = email,
				};

				this.userManager.Create(user, email);
				this.userManager.AddToRole(user.Id, AppRoles.User);
			}

			var adminUserEmail = "admin@admin.com";
			var adminUser = new User
			{
				Email = adminUserEmail,
				UserName = adminUserEmail
			};

			this.userManager.Create(adminUser, adminUserEmail);
			this.userManager.AddToRole(adminUser.Id, AppRoles.Admin);
		}
	}
}