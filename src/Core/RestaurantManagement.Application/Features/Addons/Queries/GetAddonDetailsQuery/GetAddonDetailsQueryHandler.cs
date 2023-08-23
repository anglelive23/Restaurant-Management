using MediatR;
using RestaurantManagement.Application.Abstractions;
using RestaurantManagement.Application.Exceptions;
using RestaurantManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Features.Addons.Queries.GetAddonDetailsQuery
{
    public class GetAddonDetailsQueryHandler : IRequestHandler<GetAddonDetailsQuery, IQueryable<Addon>?>
    {
        #region Fields and Properties
        private readonly IAddonsRepository _repo;
        #endregion

        #region Constructors
        public GetAddonDetailsQueryHandler(IAddonsRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<IQueryable<Addon>?> Handle(GetAddonDetailsQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetAddonDetailsQueryValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (validatorResult.Errors.Count > 0)
                throw new ValidationException(validatorResult);

            var addon = _repo.GetAll(a => a.Id == request.Id && a.IsDeleted == false);
            return await Task.FromResult(addon);
        }
        #endregion
    }
}
