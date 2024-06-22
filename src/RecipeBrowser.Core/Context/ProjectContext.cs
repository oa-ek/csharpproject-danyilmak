using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecipeBrowser.Core.Entities;
using System.Reflection.Emit;

namespace RecipeBrowser.Core.Context
{
    public class ProjectContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Seed();

            base.OnModelCreating(builder);
        }

        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Measure> Measures { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<CookingDifficulty> CookingDifficulties { get; set; }
        public DbSet<CookingType> CookingTypes { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<RecipeCollection> RecipesCollections { get; set; }
    }
}
