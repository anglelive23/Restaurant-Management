using Mapster;
using MediatR;
using RestaurantManagement.Application.Abstractions;
using RestaurantManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Features.Recipes.Commands.CreateRecipe
{
    public class CreateRecipeCommandHandler : IRequestHandler<CreateRecipeCommand, int>
    {
        #region Fields and Properties
        private readonly IRecipeRepository _repo;
        #endregion

        #region Constructors
        public CreateRecipeCommandHandler(IRecipeRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<int> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
        {
            var @recipe = request.Adapt<Recipe>();
            recipe = await _repo.AddRecipeAsync(recipe);

            return recipe != null ? recipe.Id : 0;
        }
        #endregion
    }
}
