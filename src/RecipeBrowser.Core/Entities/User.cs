using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBrowser.Core.Entities
{
    public class User : IdentityUser<Guid>, IEntity<Guid>
    {
        public string? Username { get; set; }
        public virtual ICollection<Recipe> AdminRecipes { get; set; } = new HashSet<Recipe>();
        public virtual ICollection<RecipeItem> PeopleRecipes { get; set; } = new HashSet<RecipeItem>();
    }
}
