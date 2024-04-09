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
            builder
                .Entity<RecipeItem>()
                .HasMany(x => x.Peoples)
                .WithMany(x => x.PeopleRecipes);

            builder.Seed();

            base.OnModelCreating(builder);
        }
        public DbSet<Recipe> Recipes => Set<Recipe>();
        public DbSet<RecipeItem> RecipeItems => Set<RecipeItem>();
        public DbSet<RecipeItemStatus> RecipeItemStatuses => Set<RecipeItemStatus>();
        public DbSet<RecipeLink> RecipeLinks => Set<RecipeLink>();
        public DbSet<RecipeApproveQuery> ApproveQueries => Set<RecipeApproveQuery>();
        public DbSet<RecipeAccessQuery> AccessQueries => Set<RecipeAccessQuery>();
    }
}
