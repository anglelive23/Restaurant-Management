namespace RestaurantManagement.Application.Features.Contacts.Commands.DeleteContact
{
    public class DeleteContactCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
