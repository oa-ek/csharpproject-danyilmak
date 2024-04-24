using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecipeBrowser.Core.Entities;
using RecipeBrowser.Core.Entities.Recipes;
using System.Reflection.Emit;

namespace RecipeBrowser.Core.Context
{
    public class ProjectContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Recipe> Recipes => Set<Recipe>();
        public DbSet<Review> Reviews => Set<Review>();
        public DbSet<Collection> Collections => Set<Collection>();
    }
}
