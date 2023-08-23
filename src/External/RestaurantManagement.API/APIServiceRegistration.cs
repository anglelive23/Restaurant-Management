using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using System.Reflection;

namespace RestaurantManagement.API
{
    public static class APIServiceRegistration
    {
        public static IServiceCollection AddAPIServices(this IServiceCollection services, WebApplicationBuilder builder)
        {
            // MediatR
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            // Serilog
            builder.Host.UseSerilog();
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message}{NewLine}{Exception}", theme: AnsiConsoleTheme.Code)
                .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            // Cors
            builder.Services.AddCors();

            return services;
        }
    }
}
