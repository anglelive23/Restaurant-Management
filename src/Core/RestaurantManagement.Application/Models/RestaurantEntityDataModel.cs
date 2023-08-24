namespace RestaurantManagement.Application.Models
{
    public class RestaurantEntityDataModel
    {
        public IEdmModel GetEntityDataModel()
        {
            var builder = new ODataConventionModelBuilder();

            builder.EntitySet<Addon>("Addons");
            builder.EntitySet<Address>("Addresses");

            builder.EnableLowerCamelCase();
            return builder.GetEdmModel();
        }
    }
}
