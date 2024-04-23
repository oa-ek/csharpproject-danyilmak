using Microsoft.AspNetCore.Http;
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
        public virtual ICollection<Collection> Collections {  get; set; }
        public virtual ICollection<Review> Reviews{  get; set; }
        public string? ImagePath { get; set; } = "/img/no_photo.jpg";
        public User? Users { get; set; }

        [ForeignKey(nameof(User))]
        public Guid? UserId { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
