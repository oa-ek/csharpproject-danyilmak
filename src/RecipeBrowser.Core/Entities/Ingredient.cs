using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBrowser.Core.Entities
{
    public class Ingredient : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public float Amount { get; set; }
        public virtual Measure? Measure { get; set; }

        [ForeignKey(nameof(Measure))]
        public Guid MeasureId { get; set; }
        public virtual Product? Product { get; set; }

        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; } = new HashSet<Recipe>();
    }
}
