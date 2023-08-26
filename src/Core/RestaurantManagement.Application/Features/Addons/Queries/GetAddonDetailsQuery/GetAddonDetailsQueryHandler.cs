namespace RestaurantManagement.Application.Features.Addons.Queries.GetAddonDetailsQuery
{
    public class GetAddonDetailsQueryHandler : IRequestHandler<GetAddonDetailsQuery, Addon?>
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
        public async Task<Addon?> Handle(GetAddonDetailsQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetAddonDetailsQueryValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (validatorResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validatorResult);

            var addon = await _repo.GetByIdAsync(request.Id);
            return addon;
        }
        #endregion
    }
}
