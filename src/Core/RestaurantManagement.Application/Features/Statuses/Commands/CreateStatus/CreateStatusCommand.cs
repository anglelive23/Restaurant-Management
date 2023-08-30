namespace RestaurantManagement.Application.Features.Statuses.Commands.CreateStatus
{
    public class CreateStatusCommand : IRequest<Status?>
    {
        public CreateStatusDto StatusDto { get; set; }
    }
}
