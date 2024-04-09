using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBrowser.Core.Entities
{
    public class RecipeApproveQuery : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? AdminComment { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime UpdatedOn { get; set; }
        public string? PeopleComment { get; set; }
        public RecipeItem? RecipeItem { get; set; }

        [ForeignKey(nameof(RecipeItem))]
        public Guid RecipeItemId { get; set; }

        //public ProjectItemStatus? Status { get; set; }

        //[ForeignKey(nameof(Status))]
        // public int StatusId { get; set; } = 1;

    }
}
