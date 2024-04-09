using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBrowser.Core.Entities
{
    public class Recipe : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Title { get; set; } = string.Empty;
        public string? Ingredients { get; set; } = string.Empty;
        public string? Instructions { get; set; } = string.Empty;
        public string? Collections {  get; set; } = string.Empty;
        public string? Comment {  get; set; } = string.Empty;
        public User? Admin { get; set; }

        [ForeignKey(nameof(Admin))]
        public Guid? AdminId { get; set; }
    }
}
