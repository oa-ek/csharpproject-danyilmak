using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBrowser.Core.Entities
{
    public class Recipe : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public int CookDuration { get; set; }
        public string? Description { get; set; }
        public virtual  CookingType? Type { get; set; }

        [ForeignKey(nameof(Type))]
        public Guid TypeId { get; set; }
        public virtual CookingDifficulty? Difficulty { get; set; }

        [ForeignKey(nameof(Difficulty))]
        public Guid DifficultyId { get; set; }
        public virtual User? Creator { get; set; }
        [ForeignKey(nameof(Creator))]
        public Guid CreatorId { get; set; }
        public string? ImagePath { get; set; } = "/img/recipes/no_photo.jpg";
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; } = new HashSet<Ingredient>();
        public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
        public virtual ICollection<RecipeCollection> RecipeCollections {  get; set; } = new HashSet<RecipeCollection>();
    }
}
