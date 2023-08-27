namespace RestaurantManagement.Application.Features.Contacts.Queries.GetContactDetailsQuery
{
    public class GetContactDetailsQuery : IRequest<IQueryable<Contact>>
    {
        public int Id { get; set; }
    }
}
