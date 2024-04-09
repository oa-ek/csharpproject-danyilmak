using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RecipeBrowser.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBrowser.Core.Context
{
    public static class DataSeed
    {
        public static void Seed(this ModelBuilder builder)
        {
            var adminId = _seedAdmins(builder);
            var recipeId = _seedRecipe(builder, adminId);

            _seedRecipeItemStatuses(builder);
            _seedRecipeLinks(builder, recipeId);

        }

        private static Guid _seedAdmins(ModelBuilder builder)
        {
            var adminId = Guid.NewGuid();

            var admin = new User
            {
                Id = adminId,
                UserName = "admin@projects.admin1.page",
                EmailConfirmed = true,
                NormalizedUserName = "admin@projects.admin1.page".ToUpper(),
                Email = "admin@projects.admin1.page",
                Username = "Admin1"
            };

            var admin2 = new User
            {
                Id = Guid.NewGuid(),
                UserName = "admin@projects.admin2.page",
                EmailConfirmed = true,
                NormalizedUserName = "admin@projects.admin2.page".ToUpper(),
                Email = "admin@projects.admin2.page",
                Username = "Admin2"
            };

            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            admin.PasswordHash = passwordHasher.HashPassword(admin, "Pr0#et1n1t");
            admin2.PasswordHash = passwordHasher.HashPassword(admin2, "Pr0#et1n1t");

            builder.Entity<User>()
                .HasData(admin, admin2);

            return adminId;
        }

        static void _seedRecipeItems(ModelBuilder builder, Guid recipeId)
        {
            builder.Entity<RecipeItem>().HasData(new List<RecipeItem> {
            new RecipeItem
            {
                Description = "Lorem Ipsum - це текст-\"риба\", що використовується в друкарстві та дизайні. Lorem Ipsum є, фактично, стандартною \"рибою\" аж з XVI сторіччя, коли невідомий друкар взяв шрифтову гранку та склав на ній підбірку зразків шрифтів. \"Риба\" не тільки успішно пережила п'ять століть, але й прижилася в електронному верстуванні, залишаючись по суті незмінною. Вона популяризувалась в 60-их роках минулого сторіччя завдяки виданню зразків шрифтів Letraset, які містили уривки з Lorem Ipsum, і вдруге - нещодавно завдяки програмам комп'ютерного верстування на кшталт Aldus Pagemaker, які використовували різні версії Lorem Ipsum.",
                RecipeId = recipeId,
                StatusId = 1,
                Title = "Тестовий рецепт №1"
            },
            new RecipeItem
            {
                Description = "Lorem Ipsum - це текст-\"риба\", що використовується в друкарстві та дизайні. Lorem Ipsum є, фактично, стандартною \"рибою\" аж з XVI сторіччя, коли невідомий друкар взяв шрифтову гранку та склав на ній підбірку зразків шрифтів. \"Риба\" не тільки успішно пережила п'ять століть, але й прижилася в електронному верстуванні, залишаючись по суті незмінною. Вона популяризувалась в 60-их роках минулого сторіччя завдяки виданню зразків шрифтів Letraset, які містили уривки з Lorem Ipsum, і вдруге - нещодавно завдяки програмам комп'ютерного верстування на кшталт Aldus Pagemaker, які використовували різні версії Lorem Ipsum.",
                RecipeId = recipeId,
                StatusId = 2,
                Title = "Тестовий рецепт №2"
            }
            });
        }
        static Guid _seedRecipe(ModelBuilder builder, Guid adminId)
        {
            var recipeId = Guid.NewGuid();

            builder.Entity<Recipe>().HasData(new List<Recipe>
            {
                new Recipe
                {
                    Id = recipeId,
                    Title = "Рецепт",
                    Collections = "Улюблені",
                    Ingredients = "1, 2, 3",
                    Instructions = "Помішать",
                    Comment = "Круто",
                    AdminId = adminId,
                }
            });

            return recipeId;
        }
        static void _seedRecipeItemStatuses(ModelBuilder builder)
        {
            builder.Entity<RecipeItemStatus>().HasData(
                new List<RecipeItemStatus> { new RecipeItemStatus
                {
                    Id = (int)StatusType.Draft,
                    Title = "Чернетка"
                },
                new RecipeItemStatus
                {
                    Id = (int)StatusType.Rejected,
                    Title = "Відхилено"
                },
                new RecipeItemStatus
                {
                    Id = (int)StatusType.Approved,
                    Title = "Затверджено"
                }});
        }
        static void _seedRecipeLinks(ModelBuilder builder, Guid recipeId)
        {
            builder.Entity<RecipeLink>().HasData(
                new List<RecipeLink> {
                    new RecipeLink
                    {
                        RecipeId = recipeId,
                        Name = "Рецепт Паски",
                        Url = "https://www.unian.ua/recipes/desserts/various-sweets/paska-sirna-recept-idealnogo-desertu-bez-vipichki-12596628.html"
                    },
                new RecipeLink
                    {
                        RecipeId = recipeId,
                        Name = "Рецепт картопля Фрі",
                        Url = "https://www.unian.ua/recipes/second-courses/side-dishes-with-vegetables/kartoshka-fri-v-duhovke-tri-prostyh-recepta-12590820.html"
                    }});
        }
    }
}
