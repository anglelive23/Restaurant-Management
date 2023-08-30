namespace RestaurantManagement.Application.Features.Statuses.Commands.DeleteStatus
{
    public class DeleteStatusCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
