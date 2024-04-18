using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBrowser.Core.Entities
{
    public class Review
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Title {  get; set; }

        [ForeignKey(nameof(User))]
        public Guid? UserId { get; set; }

        [ForeignKey(nameof(Recipe))]
        public Guid? RecipeId { get; set; }
    }
}
