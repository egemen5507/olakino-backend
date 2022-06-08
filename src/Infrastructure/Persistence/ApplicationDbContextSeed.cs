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
                var dietCategory1 = new DietCategory { Id = 1, Name = "Regular" };
                var dietCategory2 = new DietCategory() { Id = 2, Name = "Sportsman" };

                var diet1 = new Diet { Name = "Weak", MealsJson = "{Sabah Uyanınca: 1 su bardağı kadar hafif ılık su 1 su bardağı kadar daha soğuk su Kahvaltı: 1 su bardağı süt 3-4 yemek kaşığı kadar yulaf ezmesi 3-4 tam ceviz 1 yemek kaşığı yaban mersini Ara Öğün: 1 fincan sade Türk kahvesi 12 badem Öğlen: 1 tabak zeytinyağlı ıspanak kavurma 1 su bardağı yoğurt Az zeytinyağlı bol salata Ara Öğün: 2 dilim peynir 1 dilim ekmek Akşam: 1 orta boy ızgara balık 1 orta boy haşlanmış veya fırında patates Az zeytinyağlı bol limonlu roka salatası Ara Öğün: 3 dilim taze ananas}", DietCategoryId = dietCategory1.Id, TotalCalorie = 1017 };
                var diet2 = new Diet { Name = "Fit", MealsJson = "{Sabah Uyanınca: 1 su bardağı kadar hafif ılık su 1 su bardağı kadar daha soğuk su Kahvaltı: 1 su bardağı probiyotik veya ev yoğurdu 3-4 yemek kaşığı kadar yulaf ezmesi 10-12 badem 1 yeme kaşığı siyah kuru üzüm Ara Öğün: 1 fincan sade Türk kahvesi 10 gr bitter çikolata Öğlen: 1 tabak zeytinyağlı kuru fasulye 3-4 yemek kaşığı bulgur pilavı 1 su bardağı yoğurt Az zeytinyağlı bol salata Ara Öğün: 1 su bardağı yoğurt 1 elma Akşam: 1 orta boy biftek Az zeytinyağlı ve bol limonlu yeşil salata Ara Öğün: 1 kivi 2 ceviz}", DietCategoryId = dietCategory1.Id, TotalCalorie = 935 };
                var diet3 = new Diet { Name = "Fat", MealsJson = "{Sabah Uyanınca: 1 su bardağı kadar hafif ılık su 1 su bardağı kadar daha soğuk su Kahvaltı: 1 yumurta 1 dilim peynir 1 dilim ekmek Bol çiğ sebze 20 Ara Öğün: 1 elma 15 fındık Öğlen: 3 yemek kaşığı ton balığı 3-4 yemek kaşığı haşlanmış buğday veya kinoa Az zeytinyağlı bol salata Ara öğün: 1 su bardağı süt (kahve ile içebilirsiniz)}", DietCategoryId = dietCategory1.Id, TotalCalorie = 678 };
                var diet4 = new Diet { Name = "Rabbit", MealsJson = "{Sabah kalkınca: 2 bardak su Kahvaltı 1 tam yumurta + 2 yumurta beyazı ile yapılmış mantarlı/lorlu omlet 2-3 dilim tam buğday ekmeği 50 gr az yağlı beyaz peynir 5-6 adet zeytin Ara Öğün: 1 porsiyon meyve + 15 adet çiğ badem veya fındık Öğlen: 200 gr ızgara tavuk ile yapılmış salata veya haşlama tavuk 1 kase yoğurt 2-3 dilim tam buğday ekmeği Ara Öğün: 200 ml süt veya kefir + 2 adet kuru incir Akşam: 150 gr ızgara yağsız dana eti veya köfte Izgara sebze veya 1 porsiyon zeytinyağlı sebze yemeği 1 porsiyon kepekli makarna veya bulgur pilavı Gece: 200 ml light süt}", DietCategoryId = dietCategory2.Id, TotalCalorie = 2475 };
                var diet5 = new Diet { Name = "Wolf", MealsJson = "{Kahvaltı: 3 yumurtayla yapılmış omlet 2 dilim çavdar ya da tam buğday ekmeği 50 gr yağsız peynir Ara Öğün: İnce kesilmiş 1 dilim karpuz ya da orta boy bir ekşi elma Öğlen: 1 porsiyon kepekli makarna 200 gr ızgarada pişirilmiş ya da haşlanmış tavuk eti  Ara Öğün: 1 tatlı kaşığı reçelle karıştırılmış 50 gr yağsız yoğurt Akşam: Bolca kırmızı biber ve dereotu ile hazırlanmış ton balıklı salata}", DietCategoryId = dietCategory2.Id, TotalCalorie = 2387 };
                var diet6 = new Diet { Name = "Bear", MealsJson = "{Sabah: 5 yumurtadan omlet (2 adet sarı, diğerlerinin beyazı) Omletin içine 50 gr yağsız lor konabilir Az yağlı orta dilim peynir, domates, salatalık vs. Ara Öğün: Kepekli yağsız beyaz peynirli tost Öğle: Izgara az yağlı biftek ya da köfte Yağsız pirinç pilavı ya da makarna Ara Öğün: Bir kase light yoğurt Bir kase kiraz veya 4-5 kuru incir Akşam: Izgara balık veya tavuk Zeytinyağlı yeşillik}", DietCategoryId = dietCategory2.Id, TotalCalorie = 30154 };

                var exerciseCategory1 = new ExerciseCategory { Id = 1, Name = "Chest" };
                var exerciseCategory2 = new ExerciseCategory { Id = 2, Name = "Chest" };

                var exercise1 = new Exercise { Name = "Bench Press", ExerciseCategoryId = exerciseCategory1.Id };
                var exercise2 = new Exercise { Name = "Arm", ExerciseCategoryId = exerciseCategory1.Id };
                var exercise3 = new Exercise { Name = "Triceps", ExerciseCategoryId = exerciseCategory1.Id };
                var exercise4 = new Exercise { Name = "Leg", ExerciseCategoryId = exerciseCategory2.Id };
                var exercise5 = new Exercise { Name = "Six Pack", ExerciseCategoryId = exerciseCategory2.Id };
                var exercise6 = new Exercise { Name = "Biceps", ExerciseCategoryId = exerciseCategory2.Id };

                context.Add(dietCategory1);
                context.Add(dietCategory2);
                context.Add(diet1);
                context.Add(diet2);
                context.Add(diet3);
                context.Add(diet4);
                context.Add(diet5);
                context.Add(diet6);
                context.Add(exerciseCategory1);
                context.Add(exerciseCategory2);
                context.Add(exercise1);
                context.Add(exercise2);
                context.Add(exercise3);
                context.Add(exercise4);
                context.Add(exercise5);
                context.Add(exercise6);
            }

            await context.SaveChangesAsync();
        }
    }
}