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
            builder.Entity<Recipe>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(e => e.Type)
                    .WithMany(t => t.Recipes)
                    .HasForeignKey(e => e.TypeId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Difficulty)
                    .WithMany(d => d.Recipes)
                    .HasForeignKey(e => e.DifficultyId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Creator)
                    .WithMany(u => u.Recipes)
                    .HasForeignKey(e => e.CreatorId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(e => e.Ingredients)
                    .WithMany(i => i.Recipes);
            });

            builder.Entity<Ingredient>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(e => e.Measure)
                    .WithMany(m => m.Ingredients)
                    .HasForeignKey(e => e.MeasureId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Product)
                    .WithMany(p => p.Ingredients)
                    .HasForeignKey(e => e.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasMany(e => e.Recipes)
                    .WithOne(r => r.Creator)
                    .HasForeignKey(r => r.CreatorId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<RecipeCollection>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasMany(e => e.Recipes)
                    .WithMany(r => r.RecipeCollections);
            });
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
