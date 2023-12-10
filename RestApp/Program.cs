using Microsoft.EntityFrameworkCore;
using RestApp.DataAccess;
using RestApp.DataAccess.Repository;
using RestApp.DataAccess.Repository.Contacts;
using RestApp.Mappings;
using RestApp.Services;
using RestApp.Services.Contract;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new ApplicationException("Could not load 'DefaultConnection' connection string");
}
builder.Services.AddDbContext<RestDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddAutoMapper(typeof(UserProfile));
builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();
builder.Services.AddScoped<IRestaurantService, RestaurantService>();
builder.Services.AddAutoMapper(typeof(RestaurantProfile));
builder.Services.AddScoped<ITableRepository, TableRepository>();
builder.Services.AddScoped<ITableService, TableService>();
builder.Services.AddAutoMapper(typeof(TableProfile));
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
app.Run();
