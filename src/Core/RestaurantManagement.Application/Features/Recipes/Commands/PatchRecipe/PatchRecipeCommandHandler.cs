using Mapster;
using MediatR;
using Microsoft.AspNetCore.OData.Deltas;
using RestaurantManagement.Application.Abstractions;
using RestaurantManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Features.Recipes.Commands.PatchRecipe
{
    public class PatchRecipeCommandHandler : IRequestHandler<PatchRecipeCommand, Recipe?>
    {
        #region Fields and Properties
        private readonly IRecipeRepository _repo;
        #endregion

        #region Constructors
        public PatchRecipeCommandHandler(IRecipeRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<Recipe?> Handle(PatchRecipeCommand request, CancellationToken cancellationToken)
        {
            var checkPatch = await _repo.PartUpdateRecipeAsync(request.Id, request.PatchDto.Adapt<Delta<Recipe>>());
            return checkPatch;
        }
        #endregion
    }
}
