using MediatR;
using RestaurantManagement.Application.Abstractions;
using RestaurantManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Features.Recipes
{
    public class GetRecipesListQueryHandler : IRequestHandler<GetRecipesListQuery, IQueryable<Recipe>>
    {
        #region Fields and Properties
        private readonly IRecipeRepository _repo;
        #endregion

        #region Constructors
        public GetRecipesListQueryHandler(IRecipeRepository repo)
        {
            _repo = repo;
        }
        #endregion

        #region Interface Implementation
        public async Task<IQueryable<Recipe>> Handle(GetRecipesListQuery request, CancellationToken cancellationToken)
        {
            var recipes = _repo.GetAllAsync();
            return await Task.FromResult(recipes);
        }
        #endregion
    }
}
