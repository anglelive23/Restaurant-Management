namespace RestaurantManagement.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            #region MediatR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            #endregion

            #region Services
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<IPriceCalculator, RegularPriceCalculator>();
            services.AddScoped<ISalesOrdersService, SalesOrdersService>();
            #endregion

            return services;
        }
    }
}
