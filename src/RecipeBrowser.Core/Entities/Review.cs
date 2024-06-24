using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBrowser.Core.Entities
{
    public class Review : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Comment { get; set; }
        public float Rating { get; set; }
        public DateTime? CreationTime { get; set; }
        public virtual User? User { get; set; }
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public virtual Recipe? Recipe { get; set; }
        [ForeignKey(nameof(Recipe))]
        public Guid RecipeId { get; set; }
    }
}
