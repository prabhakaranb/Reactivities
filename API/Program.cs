using Microsoft.EntityFrameworkCore;
using Persistence;
using Application.Activities.Queries;
using Application.Activities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors();
builder.Services.AddMediatR(x =>
    x.RegisterServicesFromAssemblyContaining<GetActivityList.Handler>());
builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);

var app = builder.Build();

app.UseCors(policy =>
    policy.AllowAnyMethod()
          .AllowAnyHeader()
          .WithOrigins("http://localhost:3001", "https://localhost:3001"));
app.MapControllers();

// Initialize the database
using var scope = app.Services.CreateScope();
var service = scope.ServiceProvider;

try
{
    var context = service.GetRequiredService<AppDbContext>();
    await context.Database.MigrateAsync();
    await DbInitializer.SeedData(context);
}
catch (Exception ex)
{
    var logger = service.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred during database migration and seeding.");
    Console.WriteLine(ex.Message);
}

app.Run();
