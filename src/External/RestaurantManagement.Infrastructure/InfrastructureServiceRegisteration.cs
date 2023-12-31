﻿namespace RestaurantManagement.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region DbContext
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<RestaurantContext>();
            services.AddDbContext<RestaurantContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            #endregion

            #region Repositories
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<ITableRepository, TableRepository>();
            services.AddScoped<ISalesRepository, SalesRepository>();
            #endregion

            #region JWT
            services.Configure<JWT>(configuration.GetSection(nameof(JWT)));
            services.AddScoped<IAuthService, AuthService>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(opt =>
            {
                opt.RequireHttpsMetadata = false;
                opt.SaveToken = false;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidAudience = configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"] ?? "OdkSeYWNl/ECZJaRsjzTqQ9rGb7jp0Ovp57idk1LeGs=")),
                    ClockSkew = TimeSpan.Zero
                };
            });
            #endregion

            #region Services
            services.AddScoped<IExternalImageService, ExternalImageService>();
            #endregion

            return services;
        }
    }
}
