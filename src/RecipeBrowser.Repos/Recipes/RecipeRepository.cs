using RecipeBrowser.Core.Context;
using RecipeBrowser.Core.Entities;
using RecipeBrowser.Repos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBrowser.Repos.Recipes
{
    public class RecipeRepository : Repository<Recipe, Guid>, IRecipeRepository
    {
        public RecipeRepository(ProjectContext ctx) : base(ctx) { }

        
    }
}
