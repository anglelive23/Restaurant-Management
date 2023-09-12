namespace RestaurantManagement.Application.Features.Sales.Queries.GetSalesHeaderSalesLinesList
{
    public class GetSalesHeaderSalesLinesListQueryValidator : AbstractValidator<GetSalesHeaderSalesLinesListQuery>
    {
        public GetSalesHeaderSalesLinesListQueryValidator()
        {
            RuleFor(l => l.Id)
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
