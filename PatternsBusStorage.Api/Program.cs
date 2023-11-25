using System.Configuration;
using PatternsBusStorage.Application.Repositories;
using PatternsBusStorage.Bll.Observer;
using PatternsBusStorage.Bll.Repositories;
using PatternsBusStorage.Bll.Repositories.Proxy;
using PatternsBusStorage.Bll.Services;
using PatternsBusStorage.Dal;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Add services to the container.
var c = builder.Configuration;
builder.Services.AddSingleton(new SqlConnectionPool(c.GetConnectionString("DapperString")));
builder.Services.AddControllers();
builder.Services.AddScoped<CityServices>();
builder.Services.AddScoped<CityRepository>();
builder.Services.AddScoped<IBusRepository, BusRepository>();
builder.Services.AddScoped<BusService>();

builder.Services.AddScoped<IScheduleSubject, ScheduleSubject>();
builder.Services.AddScoped<BusStopService>();
builder.Services.AddScoped<BusStopRepository>();

builder.Services.AddScoped<BusRouteService>();
builder.Services.AddScoped<BusRouteRepository>();

builder.Services.AddScoped<ScheduleRepository>();
builder.Services.AddScoped<ScheduleService>();

builder.Services.AddScoped<IUserActionsRepository, UserActionsRepository>();
builder.Services.AddScoped<UserActionsService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserService>();

builder.Services.AddScoped<BusProxyRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
