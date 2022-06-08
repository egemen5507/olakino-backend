using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.ValueObjects;
using CleanArchitecture.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            var administratorRole = new IdentityRole("Administrator");

            if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
            {
                await roleManager.CreateAsync(administratorRole);
            }

            var administrator = new ApplicationUser
                { UserName = "administrator@localhost", Email = "administrator@localhost" };

            if (userManager.Users.All(u => u.UserName != administrator.UserName))
            {
                await userManager.CreateAsync(administrator, "Administrator1!");
                await userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
            }
        }

        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            // Seed, if necessary
            if (!context.DietCategories.Any())
            {
                var dietCategory = new DietCategory { Id = 1, Name = "Ketojenik" };

                var diet = new Diet { Name = "Alafortanfoni", MealsJson = "{}", DietCategoryId = dietCategory.Id, TotalCalorie = 456 };
                var diet1 = new Diet { Name = "Alafortanfoni", MealsJson = "{}", DietCategoryId = dietCategory.Id, TotalCalorie = 456 };
                var diet2 = new Diet { Name = "Alafortanfoni", MealsJson = "{}", DietCategoryId = dietCategory.Id, TotalCalorie = 456 };
                var diet3 = new Diet { Name = "Alafortanfoni", MealsJson = "{}", DietCategoryId = dietCategory.Id, TotalCalorie = 456 };
                var diet4 = new Diet { Name = "Alafortanfoni", MealsJson = "{}", DietCategoryId = dietCategory.Id, TotalCalorie = 456 };
                var diet5 = new Diet { Name = "Alafortanfoni", MealsJson = "{}", DietCategoryId = dietCategory.Id, TotalCalorie = 456 };

                var exerciseCategory = new ExerciseCategory { Id = 1, Name = "Chest" };

                var exercise = new Exercise { Name = "Bench Press", ExerciseCategoryId = exerciseCategory.Id };

                context.Add(dietCategory);
                context.Add(diet);
                context.Add(exerciseCategory);
                context.Add(exercise);
            }

            await context.SaveChangesAsync();
        }
    }
}