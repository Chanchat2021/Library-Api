using Microsoft.EntityFrameworkCore;
using NeuLibrary.API;
using NeuLibrary.Application.Services;
using NeuLibrary.Application.Services.Interfaces;
using NeuLibrary.Domain.Entity;
using NeuLibrary.Infrastructure;
using NeuLibrary.Infrastructure.Repositories;
using NeuLibrary.Infrastructure.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var connectionString = configuration.GetConnectionString("LibraryDBContext");
builder.Services.AddDbContextPool<LibraryDBContext>(c =>
{
    c.UseSqlServer(configuration["ConnectionStrings:LibraryDBContext"]);
});
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IReserveService, ReserveService>();
builder.Services.AddScoped<IUserRolePermissionService, UserRolePermissionService>();
builder.Services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();
builder.Services.AddScoped<IGenericRepository<Book>, GenericRepository<Book>>();
builder.Services.AddScoped<IGenericRepository<Reserve>, GenericRepository<Reserve>>();
builder.Services.AddScoped<IGenericRepository<UserRolePermission>, GenericRepository<UserRolePermission>>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "_myAllowSpecificOrigins",
                      policy =>
                      {
                          policy.AllowAnyMethod();
                          policy.AllowAnyHeader();
                          policy.WithOrigins("http://localhost:4200");
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<GlobalExceptionHandler>();
app.UseAuthorization();
app.UseCors(MyAllowSpecificOrigins);
app.MapControllers();

app.Run();
