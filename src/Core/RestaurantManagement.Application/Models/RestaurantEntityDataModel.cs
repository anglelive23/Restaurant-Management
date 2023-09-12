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
            builder.EntitySet<Recipe>("Recipes");
            builder.EntitySet<Location>("Locations");
            builder.EntitySet<Status>("Statuses");
            builder.EntitySet<Table>("Tables");
            builder.EntitySet<SalesHeader>("SalesOrders");

            builder.EnableLowerCamelCase();
            return builder.GetEdmModel();
        }
    }
}
