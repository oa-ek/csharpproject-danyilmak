using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBrowser.Core.Entities
{
    public class RecipeAccessQuery : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public User People { get; set; }

        [ForeignKey(nameof(People))]
        public Guid PeopleId { get; set; }

        public RecipeItem RecipeItem { get; set; }

        [ForeignKey(nameof(RecipeItem))]
        public Guid RecipeItemId { get; set; }
    }
}
