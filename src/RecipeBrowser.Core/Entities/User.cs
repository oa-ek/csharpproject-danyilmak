using Microsoft.AspNetCore.Identity;
using RecipeBrowser.Core.Entities.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBrowser.Core.Entities
{
    public class User : IdentityUser<Guid>, IEntity<Guid>
    {
        public string? FullName { get; set; }
        public virtual ICollection<Recipe> UserRecipes { get; set; } = new HashSet<Recipe>();
    }
}
