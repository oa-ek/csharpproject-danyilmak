using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBrowser.Core.Entities
{
    public class RecipeCollection : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public virtual User? User { get; set; }
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; } = new HashSet<Recipe>();
    }
}
