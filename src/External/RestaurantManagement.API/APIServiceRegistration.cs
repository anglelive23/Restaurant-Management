namespace RestaurantManagement.API
{
    public static class APIServiceRegistration
    {
        public static IServiceCollection AddAPIServices(this IServiceCollection services, WebApplicationBuilder builder)
        {
            #region MediatR
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            #endregion

            #region Cache
            builder.Services.AddOutputCache(options =>
            {
                //options.AddBasePolicy(builder => builder.Expire(TimeSpan.FromMinutes(10)));
                options.AddPolicy("Addons", policy => policy.Tag("Addons").Expire(TimeSpan.FromHours(1)));
                options.AddPolicy("Addresses", policy => policy.Tag("Addresses").Expire(TimeSpan.FromHours(1)));
                options.AddPolicy("Categories", policy => policy.Tag("Categories").Expire(TimeSpan.FromHours(1)));
                options.AddPolicy("Contacts", policy => policy.Tag("Contacts").Expire(TimeSpan.FromHours(1)));
                options.AddPolicy("Recipes", policy => policy.Tag("Recipes").Expire(TimeSpan.FromHours(1)));
                options.AddPolicy("Locations", policy => policy.Tag("Locations").Expire(TimeSpan.FromHours(1)));
                options.AddPolicy("Statuses", policy => policy.Tag("Statuses").Expire(TimeSpan.FromHours(1)));
                options.AddPolicy("Addon", policy => policy.Tag("Addons").SetVaryByQuery("key").Expire(TimeSpan.FromHours(1)));
                options.AddPolicy("Address", policy => policy.Tag("Addresses").SetVaryByQuery("key").Expire(TimeSpan.FromHours(1)));
                options.AddPolicy("Category", policy => policy.Tag("Categories").SetVaryByQuery("key").Expire(TimeSpan.FromHours(1)));
                options.AddPolicy("Contact", policy => policy.Tag("Contacts").SetVaryByQuery("key").Expire(TimeSpan.FromHours(1)));
                options.AddPolicy("Recipe", policy => policy.Tag("Recipes").SetVaryByQuery("key").Expire(TimeSpan.FromHours(1)));
                options.AddPolicy("Location", policy => policy.Tag("Locations").SetVaryByQuery("key").Expire(TimeSpan.FromHours(1)));
                options.AddPolicy("Status", policy => policy.Tag("Statuses").SetVaryByQuery("key").Expire(TimeSpan.FromHours(1)));

            });
            #endregion

            #region Serilog
            builder.Host.UseSerilog();
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message}{NewLine}{Exception}", theme: AnsiConsoleTheme.Code)
                .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            #endregion

            #region Cors
            builder.Services.AddCors();
            #endregion

            return services;
        }
    }
}
