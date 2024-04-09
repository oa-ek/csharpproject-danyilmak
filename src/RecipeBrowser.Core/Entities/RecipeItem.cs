using RecipeBrowser.Core.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBrowser.Core.Entities
{
    public class RecipeItem : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public Recipe? Recipe { get; set; }

        [ForeignKey(nameof(Recipe))]
        public Guid RecipeId { get; set; }
        public virtual ICollection<User> Peoples { get; set; } = new HashSet<User>();
        public DateTime StatusDate { get; set; } = DateTime.Now;
        public RecipeItemStatus Status { get; set; }

        [ForeignKey(nameof(Status))]
        public int StatusId { get; set; } = (int)StatusType.Draft;

        public virtual ICollection<RecipeApproveQuery> ApproveQueries { get; set; } = new HashSet<RecipeApproveQuery>();
        public virtual ICollection<RecipeAccessQuery> AccessQueries { get; set; } = new HashSet<RecipeAccessQuery>();
    }
}