﻿namespace RestaurantManagement.Application.Features.Addresses.Queries.GetAddressDetailsQuery
{
    public class GetAddressDetailsQueryHandler : IRequestHandler<GetAddressDetailsQuery, Address?>
    {
        #region Fields and Properties
        private readonly IAddressRepository _repo;
        #endregion

        #region Constructors
        public GetAddressDetailsQueryHandler(IAddressRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<Address?> Handle(GetAddressDetailsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var validator = new GetAddressDetailsQueryValidator();
                await validator.ValidateAndThrowAsync(request, cancellationToken);
                var address = await _repo.GetByIdAsync(request.Id);
                return address;
            }
            catch (Exception ex) when (ex is FluentValidation.ValidationException
                                    || ex is DataFailureException)
            {
                throw;
            }
        }
        #endregion
    }
}
