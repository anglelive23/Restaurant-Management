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
                options.AddPolicy("Addon", policy => policy.Tag("Addons").SetVaryByQuery("key").Expire(TimeSpan.FromHours(1)));
                options.AddPolicy("Address", policy => policy.Tag("Addresses").SetVaryByQuery("key").Expire(TimeSpan.FromHours(1)));

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
