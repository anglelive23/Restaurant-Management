namespace RestaurantManagement.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region DbContext
            services.AddDbContext<RestaurantContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            #endregion

            #region Repositories
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IAddonsRepository, AddonsRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            #endregion

            return services;
        }
    }
}
