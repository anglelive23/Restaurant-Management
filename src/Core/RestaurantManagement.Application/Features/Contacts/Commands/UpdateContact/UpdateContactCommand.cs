namespace RestaurantManagement.Application.Features.Contacts.Commands.UpdateContact
{
    public class UpdateContactCommand : IRequest<Contact?>
    {
        public int Id { get; set; }
        public UpdateContactDto ContactDto { get; set; }
    }
}
