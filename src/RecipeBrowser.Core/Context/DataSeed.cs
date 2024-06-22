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
            var (arID, urID) = _seedRoles(builder);

            _seedUsers(builder, urID, arID);

            _seedMeasures(builder);
            _seedProducts(builder);
            _seedCookingParameters(builder);
        }

        private static void _seedCookingParameters(ModelBuilder builder)
        {
            builder.Entity<CookingType>().HasData(
                new CookingType() { Title = "Стави в мікрохвильовці" },
                new CookingType() { Title = "Страви для грилю, барбекю, мангалу" },
                new CookingType() { Title = "Страви в мультиварці" },
                new CookingType() { Title = "Страви без спеціальних пристосувань" },
                new CookingType() { Title = "Страви на плиті" },
                new CookingType() { Title = "Страви в духовці" },
                new CookingType() { Title = "Страви в пароварці" }
                );

            builder.Entity<CookingDifficulty>().HasData(
                new CookingDifficulty() { Title = "Легко" },
                new CookingDifficulty() { Title = "Нормально" },
                new CookingDifficulty() { Title = "Важко" }
                );
        }

        private static void _seedProducts(ModelBuilder builder)
        {
            var fruitTypeId = Guid.NewGuid();
            var vegetableTypeId = Guid.NewGuid();
            var meatTypeId = Guid.NewGuid();
            var seafoodTypeId = Guid.NewGuid();
            var spiceTypeId = Guid.NewGuid();
            var otherTypeId = Guid.NewGuid();

            builder.Entity<ProductType>()
                .HasData(
                new ProductType() { Id = fruitTypeId, Title = "Фрукти" },
                new ProductType() { Id = vegetableTypeId, Title = "Овочі" },
                new ProductType() { Id = meatTypeId, Title = "М'ясо" },
                new ProductType() { Id = seafoodTypeId, Title = "Морепродукти" },
                new ProductType() { Id = spiceTypeId, Title = "Спеції" },
                new ProductType() { Id = otherTypeId, Title = "Інше" }
                );

            builder.Entity<Product>()
                .HasData(
                new Product { Id = Guid.NewGuid(), Title = "Яблуко", TypeId = fruitTypeId },
                new Product { Id = Guid.NewGuid(), Title = "Банан", TypeId = fruitTypeId },
                new Product { Id = Guid.NewGuid(), Title = "Апельсин", TypeId = fruitTypeId },
                new Product { Id = Guid.NewGuid(), Title = "Помідор", TypeId = vegetableTypeId },
                new Product { Id = Guid.NewGuid(), Title = "Морква", TypeId = vegetableTypeId },
                new Product { Id = Guid.NewGuid(), Title = "Картопля", TypeId = vegetableTypeId },
                new Product { Id = Guid.NewGuid(), Title = "Куряча грудка", TypeId = meatTypeId },
                new Product { Id = Guid.NewGuid(), Title = "Свинина", TypeId = meatTypeId },
                new Product { Id = Guid.NewGuid(), Title = "Яловичина", TypeId = meatTypeId },
                new Product { Id = Guid.NewGuid(), Title = "Філе лосося", TypeId = seafoodTypeId },
                new Product { Id = Guid.NewGuid(), Title = "Креветки", TypeId = seafoodTypeId },
                new Product { Id = Guid.NewGuid(), Title = "Тунець", TypeId = seafoodTypeId },
                new Product { Id = Guid.NewGuid(), Title = "Сіль", TypeId = spiceTypeId },
                new Product { Id = Guid.NewGuid(), Title = "Чорний перець", TypeId = spiceTypeId },
                new Product { Id = Guid.NewGuid(), Title = "Паприка", TypeId = spiceTypeId },
                new Product { Id = Guid.NewGuid(), Title = "Оливкова олія", TypeId = otherTypeId },
                new Product { Id = Guid.NewGuid(), Title = "Масло", TypeId = otherTypeId },
                new Product { Id = Guid.NewGuid(), Title = "Молоко", TypeId = otherTypeId },
                new Product { Id = Guid.NewGuid(), Title = "Яйця", TypeId = otherTypeId },
                new Product { Id = Guid.NewGuid(), Title = "Борошно", TypeId = otherTypeId },
                new Product { Id = Guid.NewGuid(), Title = "Цибуля", TypeId = vegetableTypeId },
                new Product { Id = Guid.NewGuid(), Title = "Часник", TypeId = vegetableTypeId },
                new Product { Id = Guid.NewGuid(), Title = "Огірок", TypeId = vegetableTypeId },
                new Product { Id = Guid.NewGuid(), Title = "Сир", TypeId = otherTypeId },
                new Product { Id = Guid.NewGuid(), Title = "Хліб", TypeId = otherTypeId },
                new Product { Id = Guid.NewGuid(), Title = "Цукор", TypeId = otherTypeId },
                new Product { Id = Guid.NewGuid(), Title = "Бекон", TypeId = meatTypeId },
                new Product { Id = Guid.NewGuid(), Title = "Сметана", TypeId = otherTypeId },
                new Product { Id = Guid.NewGuid(), Title = "Гриби", TypeId = vegetableTypeId }
                );

        }

        private static void _seedMeasures(ModelBuilder builder)
        {
            builder.Entity<Measure>()
                .HasData(
                new Measure() { Title = "гр." },
                new Measure() { Title = "кг." },
                new Measure() { Title = "л." },
                new Measure() { Title = "мл." },
                new Measure() { Title = "стол. л." },
                new Measure() { Title = "чай. л." },
                new Measure() { Title = "штуки" }
                );
        }

        private static (Guid, Guid) _seedRoles(ModelBuilder builder)
        {
            var ADMIN_ROLE_ID = Guid.NewGuid();
            var USER_ROLE_ID = Guid.NewGuid();

            builder.Entity<IdentityRole<Guid>>()
               .HasData(
                   new IdentityRole<Guid>
                   {
                       Id = ADMIN_ROLE_ID,
                       Name = "Admin",
                       NormalizedName = "ADMIN",
                       ConcurrencyStamp = ADMIN_ROLE_ID.ToString()
                   },
                   new IdentityRole<Guid>
                   {
                       Id = USER_ROLE_ID,
                       Name = "User",
                       NormalizedName = "USER",
                       ConcurrencyStamp = USER_ROLE_ID.ToString()
                   }
               );


            return (ADMIN_ROLE_ID, USER_ROLE_ID);

        }

        private static void _seedUsers(ModelBuilder builder, Guid USER_ROLE_ID, Guid ADMIN_ROLE_ID)
        {
            var user1Id = Guid.NewGuid();
            var user2Id = Guid.NewGuid();

            var user = new User
            {
                Id = user1Id,
                UserName = "admin@recipes.daniil.page",
                EmailConfirmed = true,
                NormalizedUserName = "admin@recipes.daniil.page".ToUpper(),
                Email = "admin@recipes.daniil.page",
                NormalizedEmail = "admin@recipes.daniil.page".ToUpper(),
                SecurityStamp = Guid.NewGuid().ToString(),
                FullName = "Даниїл Максимчук"
            };

            var user2 = new User
            {
                Id = user2Id,
                UserName = "user@recipes.daniil.page",
                EmailConfirmed = true,
                NormalizedUserName = "user@recipes.daniil.page".ToUpper(),
                Email = "user@recipes.daniil.page",
                NormalizedEmail = "user@recipes.daniil.page".ToUpper(),
                SecurityStamp = Guid.NewGuid().ToString(),
                FullName = "Ігор Куренко"
            };

            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            user.PasswordHash = passwordHasher.HashPassword(user, "Pr0#et1n1t");
            user2.PasswordHash = passwordHasher.HashPassword(user2, "Pr0#et1n1t");

            builder.Entity<User>()
                .HasData(user, user2);

            builder.Entity<IdentityUserRole<Guid>>()
              .HasData(
                  new IdentityUserRole<Guid>
                  {
                      RoleId = ADMIN_ROLE_ID,
                      UserId = user1Id
                  },
                  new IdentityUserRole<Guid>
                  {
                      RoleId = USER_ROLE_ID,
                      UserId = user2Id
                  }
              );
        }
    }
}