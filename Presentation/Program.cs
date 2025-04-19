using Microsoft.OpenApi.Models; // Ensure this is included
using Microsoft.EntityFrameworkCore; // Ensure this is included
using Application;
using Infrastructure;
using Infrastructure.PersistenceDb;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationService(builder.Configuration);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });

// Add Swagger/OpenAPI services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Assignment", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Enable middleware to serve generated Swagger as JSON endpoint
    app.UseSwagger();

    // Enable middleware to serve Swagger UI
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty; // Optional: Serve Swagger UI at root (/)
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
