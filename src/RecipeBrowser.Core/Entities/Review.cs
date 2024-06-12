using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeBrowser.Core.Entities.Recipes;

namespace RecipeBrowser.Core.Entities
{
    public class Review : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Text {  get; set; }
        public double? Rating { get; set; }
        public User? Users { get; set; }
        public Recipe? Recipes { get; set; }

        [ForeignKey(nameof(User))]
        public Guid? UserId { get; set; }

        [ForeignKey(nameof(Recipe))]
        public Guid? RecipeId { get; set; }
    }
}
