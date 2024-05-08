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

            var userId = _seedUsers(builder, urID, arID);

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

        private static Guid _seedUsers(ModelBuilder builder, Guid USER_ROLE_ID, Guid ADMIN_ROLE_ID)
        {
            var userId = Guid.NewGuid();

            var user = new User
            {
                Id = userId,
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
                Id = Guid.NewGuid(),
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
                      UserId = userId
                  },
                  new IdentityUserRole<Guid>
                  {
                      RoleId = USER_ROLE_ID,
                      UserId = userId
                  }
              );

            return userId;
        }
    }
}