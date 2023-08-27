namespace RestaurantManagement.Application.Models
{
    public class RestaurantEntityDataModel
    {
        public IEdmModel GetEntityDataModel()
        {
            var builder = new ODataConventionModelBuilder();

            builder.EntitySet<Addon>("Addons");
            builder.EntitySet<Address>("Addresses");
            builder.EntitySet<Category>("Categories");
            builder.EntitySet<Contact>("Contacts");

            builder.EnableLowerCamelCase();
            return builder.GetEdmModel();
        }
    }
}
