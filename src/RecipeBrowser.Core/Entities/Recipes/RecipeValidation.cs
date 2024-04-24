using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBrowser.Core.Entities.Recipes
{
    public class RecipeValidator : AbstractValidator<Recipe>
    {
        public RecipeValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Поле Назва рецепту обов'язкове")
                .MinimumLength(5).WithMessage("Мінімальна довжина поля 5 символів");
        }
    }
}
