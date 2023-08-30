namespace RestaurantManagement.Application.Features.Statuses.Commands.UpdateStatus
{
    public class UpdateStatusCommand : IRequest<Status?>
    {
        public int Id { get; set; }
        public UpdateStatusDto StatusDto { get; set; }
    }
}
