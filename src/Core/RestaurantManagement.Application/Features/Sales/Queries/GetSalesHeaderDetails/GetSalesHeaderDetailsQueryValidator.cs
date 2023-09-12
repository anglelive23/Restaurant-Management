namespace RestaurantManagement.Application.Features.Sales.Queries.GetSalesHeaderDetails
{
    public class GetSalesHeaderDetailsQueryValidator : AbstractValidator<GetSalesHeaderDetailsQuery>
    {
        public GetSalesHeaderDetailsQueryValidator()
        {
            RuleFor(s => s.Id)
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
