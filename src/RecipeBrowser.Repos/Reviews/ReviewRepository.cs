using RecipeBrowser.Core.Context;
using RecipeBrowser.Core.Entities;
using RecipeBrowser.Core.Entities.Recipes;
using RecipeBrowser.Repos.Common;
using RecipeBrowser.Repos.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBrowser.Repos.Reviews
{
    public class ReviewRepository : Repository<Review, Guid>, IReviewRepository
    {
        public ReviewRepository(ProjectContext ctx) : base(ctx) { }


    }
}
