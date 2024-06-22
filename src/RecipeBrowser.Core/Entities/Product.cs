using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBrowser.Core.Entities
{
    public class Product : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public virtual ProductType? Type { get; set; }

        [ForeignKey(nameof(Type))]
        public Guid TypeId { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; } = new HashSet<Ingredient>();
    }
}
