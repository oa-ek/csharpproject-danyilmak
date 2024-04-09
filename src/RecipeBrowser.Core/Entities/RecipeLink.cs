using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBrowser.Core.Entities
{
    public class RecipeLink : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Url { get; set; }

        public Recipe? Recipe { get; set; }
        [ForeignKey(nameof(Recipe))]
        public Guid? RecipeId { get; set; }
    }
}
