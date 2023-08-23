using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using RestaurantManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Models
{
    public class RestaurantEntityDataModel
    {
        public IEdmModel GetEntityDataModel()
        {
            var builder = new ODataConventionModelBuilder();

            builder.EntitySet<Addon>("Addons");

            builder.EnableLowerCamelCase();
            return builder.GetEdmModel();
        }
    }
}
