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
        public string? FullName { get; set; }
        public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
        public virtual ICollection<RecipeCollection> RecipeCollecitons { get; set; } = new HashSet<RecipeCollection>();
    }
}
