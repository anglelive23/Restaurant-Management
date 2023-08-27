namespace RestaurantManagement.Application.Features.Contacts.Commands.CreateContact
{
    public class CreateContactCommand : IRequest<Contact>
    {
        public CreateContactDto ContactDto { get; set; }
    }
}
