using RestaurantManagement.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddOData(options =>
{
    options.AddRouteComponents("api/odata", new RestaurantEntityDataModel().GetEntityDataModel()).Select().Filter().OrderBy().Expand().SetMaxTop(1000);
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "RestaurantManagement.API", Version = "v1" });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

builder.Services.AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddAPIServices(builder);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors(cors => cors.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.MapControllers();
app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
app.UseOutputCache();
app.Run();
