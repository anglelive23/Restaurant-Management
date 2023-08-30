namespace RestaurantManagement.Application.Features.Locations.Commands.UpdateLocation
{
    public class UpdateLocationCommandValidator : AbstractValidator<UpdateLocationCommand>
    {
        public UpdateLocationCommandValidator()
        {
            RuleFor(l => l.Id)
                .NotEmpty().WithMessage("{PropertyName} is required!");


            RuleFor(l => l.LocationDto.Name)
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .NotNull().WithMessage("{PropertyName} cannot be null!")
                .MaximumLength(50).WithMessage("{PropertyName} has max length of 50!");


            RuleFor(l => l.LocationDto.Description)
                .MaximumLength(250).WithMessage("{PropertyName} has max length of 250!");


            RuleFor(l => l.LocationDto.County)
                .MaximumLength(50).WithMessage("{PropertyName} has max length of 50!");


            RuleFor(l => l.LocationDto.Town)
                .MaximumLength(50).WithMessage("{PropertyName} has max length of 50!");


            RuleFor(l => l.LocationDto.SeatQty)
                .NotEmpty().WithMessage("{PropertyName} is required!");

            RuleFor(l => l.LocationDto.LastModifiedBy)
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
