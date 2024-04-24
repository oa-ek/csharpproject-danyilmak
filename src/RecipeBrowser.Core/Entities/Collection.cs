using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeBrowser.Core.Entities.Recipes;

namespace RecipeBrowser.Core.Entities
{
    public class Collection
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Title { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
