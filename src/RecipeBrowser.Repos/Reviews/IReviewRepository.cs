using RecipeBrowser.Core.Entities;
using RecipeBrowser.Repos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBrowser.Repos.Reviews
{
    public interface IReviewRepository : IRepository<Review, Guid>
    {
    }
}
