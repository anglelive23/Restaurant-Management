using Microsoft.AspNetCore.OData;
using RestaurantManagement.API;
using RestaurantManagement.Application;
using RestaurantManagement.Application.Models;
using RestaurantManagement.Infrastructure;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddOData(options =>
{
    options.AddRouteComponents("api/odata", new RestaurantEntityDataModel().GetEntityDataModel()).Select().Filter().OrderBy().Expand().SetMaxTop(1000);
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
app.UseAuthorization();
app.UseCors(cors => cors.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.MapControllers();
app.UseOutputCache();
app.Run();
