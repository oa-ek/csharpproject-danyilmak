using RecipeBrowser.Core.Entities.Recipes;
using RecipeBrowser.Repos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBrowser.Repos.Recipes
{
    public interface IRecipeRepository : IRepository<Recipe, Guid>
    {

    }
}
